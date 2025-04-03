using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using inventryManagementSystem.Controllers;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Views
{
    public partial class ExpiredDate : UserControl
    {
        MedicineController MedicineController = new MedicineController();
        List<Medicine> nearExpiredDate = new List<Medicine>(); // Store data globally

        public ExpiredDate()
        {
            InitializeComponent();
            InitializeGrid();
            loadData();
        }

        private void InitializeGrid()
        {
            // Add a remove button column
            DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn();
            removeButton.HeaderText = "Action";
            removeButton.Text = "Remove";
            removeButton.UseColumnTextForButtonValue = true;
            removeButton.Name = "RemoveButton";
            dataGridViewExpiredDate.Columns.Add(removeButton);

            // Handle cell click event
            dataGridViewExpiredDate.CellClick += DataGridViewExpiredDate_CellClick;
            dataGridViewExpiredDate.CellFormatting += DataGridViewExpiredDate_CellFormatting;
        }

        public void loadData()
        {
            DateTime today = DateTime.Today;
            DateTime fifteenDaysAbove = today.AddDays(30);

            List<Medicine> medicines = MedicineController.GetAllMedicine();
            nearExpiredDate = medicines
                .Where(me => me.ExDatee <= fifteenDaysAbove)
                .ToList();

            dataGridViewExpiredDate.DataSource = nearExpiredDate;
            dataGridViewExpiredDate.Font = new Font("Arial", 14, FontStyle.Regular);
        }

        private void DataGridViewExpiredDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewExpiredDate.Columns["RemoveButton"].Index && e.RowIndex >= 0)
            {
                // Get selected medicine
                Medicine selectedMedicine = nearExpiredDate[e.RowIndex];

                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to remove {selectedMedicine.Name}?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Remove from database
                    MedicineController.RemoveMedicine(selectedMedicine.Id);

                    // Remove from list and update grid
                    nearExpiredDate.RemoveAt(e.RowIndex);
                    dataGridViewExpiredDate.DataSource = null;
                    dataGridViewExpiredDate.DataSource = nearExpiredDate;
                }
            }
        }

        private void DataGridViewExpiredDate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewExpiredDate.Columns[e.ColumnIndex].Name == "RemoveButton" && e.RowIndex >= 0)
            {
                dataGridViewExpiredDate.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                dataGridViewExpiredDate.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                dataGridViewExpiredDate.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font("Arial", 12, FontStyle.Bold);
            }
        }
    }
}
