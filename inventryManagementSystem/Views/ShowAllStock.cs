using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using inventryManagementSystem.Controllers;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Views
{
    public partial class ShowAllStock : UserControl
    {
        List<Medicine> avalableList = new List<Medicine>();
        MedicineController MedicineController = new MedicineController();

        public ShowAllStock()
        {
            InitializeComponent();
            AddColumns();
            addDate();
             // Add columns, including the Remove button
        }

        private void AddColumns()
        {
            // Add a Remove button column
            DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "Remove",
                Text = "Remove",
                UseColumnTextForButtonValue = true // Display "Remove" on all buttons
            };

            removeButton.DefaultCellStyle.BackColor = Color.Red;
            removeButton.DefaultCellStyle.ForeColor = Color.Red;

            dataGridViewStock.Columns.Add(removeButton);

            // Set font
            dataGridViewStock.Font = new Font("Arial", 14, FontStyle.Regular);

            // Handle button click event
            dataGridViewStock.CellClick += DataGridViewStock_CellClick;

        }

        public void addDate()
        {
            List<Medicine> list = MedicineController.GetAllMedicine();

            // Sort list: Show unavailable items first
            avalableList = list
                .Where(me => me.ExDatee >= DateTime.Today)
                .OrderBy(me => me.Available) // False (0) first, True (1) after
                .ToList();

            dataGridViewStock.DataSource = null;
            dataGridViewStock.DataSource = avalableList;
            //AddColumns();

        }

        private void DataGridViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewStock.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                // Get the selected medicine
                Medicine selectedMedicine = avalableList[e.RowIndex];
                string firstColumnValue = dataGridViewStock.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                Console.WriteLine(firstColumnValue);

                // Ask for confirmation
                DialogResult result = MessageBox.Show($"Are you sure you want to remove {selectedMedicine.Name}?",
                    "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Remove from the list
                    avalableList.RemoveAt(e.RowIndex);
                    MedicineController.RemoveMedicine(int.Parse(firstColumnValue));

                    // Update the DataGridView
                    dataGridViewStock.DataSource = null;
                    dataGridViewStock.DataSource = avalableList;
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();

            var filteredList = avalableList
                .Where(m => m.Name.ToLower().Contains(searchText))
                .ToList();

            dataGridViewStock.DataSource = null;
            dataGridViewStock.DataSource = filteredList;
            //AddColumns();
        }
    }
}
