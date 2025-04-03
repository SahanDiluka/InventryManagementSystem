using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using inventryManagementSystem.Controllers;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Views
{
    public partial class addBIll : UserControl
    {

        int days = 0;
        int i;

        MedicineController medicineController = new MedicineController();
        BillModelController BillModelController = new BillModelController();
        public addBIll()
        {
            InitializeComponent();
            startUpDataGridView();
            this.Load += addBIll_Load;
            drugNameTextBox.KeyDown += drugNameTextBox_KeyDown;
            drugDoseTextBox.KeyDown += drugDoseTextBox_KeyDown;
            dataGridView1.CellClick += dataGridView1_CellClick;


        }
       
        
        private void drugDoseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the default "ding" sound
                addMoreBtn.PerformClick(); // Simulate a button click
                drugNameTextBox.Select();
            }
        }
        
        
        private void addBIll_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() => drugNameTextBox.Focus()));
        }
        
        
        
        
        private void drugNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView2.Visible && dataGridView2.Rows.Count > 0)
            {
                int rowIndex = dataGridView2.CurrentCell?.RowIndex ?? -1;

                if (e.KeyCode == Keys.Down) // Move down
                {
                    if (rowIndex < dataGridView2.Rows.Count - 1)
                    {
                        rowIndex++;
                        dataGridView2.CurrentCell = dataGridView2.Rows[rowIndex].Cells[0];
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up) // Move up
                {
                    if (rowIndex > 0)
                    {
                        rowIndex--;
                        dataGridView2.CurrentCell = dataGridView2.Rows[rowIndex].Cells[0];
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter) // Select item
                {
                    if (rowIndex >= 0)
                    {
                        drugNameTextBox.Text = dataGridView2.Rows[rowIndex].Cells["Name"].Value.ToString();
                        dataGridView2.Visible = false;
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true; // Prevent beep sound
                    drugDoseTextBox.Select();
                }
            }
        }


        public void startUpDataGridView() {
            DaysOrWeekTextBox.Text = "2";
            WeekRadioButton.Checked = true;
            dataGridView2.Font = new Font("Arial", 12, FontStyle.Bold);
          
        }

        private void addMoreBtn_Click(object sender, EventArgs e)
        {
            
          
            if (string.IsNullOrWhiteSpace(drugDoseTextBox.Text) || string.IsNullOrWhiteSpace(drugNameTextBox.Text) || string.IsNullOrWhiteSpace(DaysOrWeekTextBox.Text))
            {

                MessageBox.Show("Enter data to add a bill!");
                drugDoseTextBox.Text = "";
                drugNameTextBox.Text = "";

            }
            else
            {
                //check if the dose is in fLoat
                float dose;

                if (float.TryParse(drugDoseTextBox.Text, out dose))
                {
                    dataGridView1.Visible = true;
                    dataGridView1.Font = new Font("Arial", 14, FontStyle.Regular);


                    dose = float.Parse(drugDoseTextBox.Text);

                    String name = drugNameTextBox.Text;

                    int id = BillModelController.getMaxId() + 1;
                    

                    if (WeekRadioButton.Checked)
                    {
                        days = 7 * int.Parse(DaysOrWeekTextBox.Text);
                    }
                    else if (daysRadioButton.Checked)
                    {

                        days = int.Parse(DaysOrWeekTextBox.Text);
                    }


                    float price = (medicineController.GetMedicinePrice(name) / medicineController.GetMedicineDose(name)) * (dose) * (days);

                    float amount = (dose / medicineController.GetMedicineDose(name)) * days;


                    List<Medicine> list = medicineController.FindMedicineByName(name);

                    if (list == null || list.Count == 0)
                    {
                        MessageBox.Show("This drug is not in the database");
                        drugNameTextBox.Select();
                    }
                    else
                    {
                        Medicine availableMedicine = list
                             .Where(n => n.Amount > amount && n.ExDatee > DateTime.Today && n.Amount > 30)
                             .OrderBy(n => n.ExDatee) // Sort by expiration date (closest first)
                             .FirstOrDefault();


                        if (availableMedicine == null)
                        {
                            MessageBox.Show("This drug is either out of stock or expired!");
                            drugNameTextBox.Select();
                        }
                        else
                        {
                            medicineController.setamount(availableMedicine, amount);
                            BillModelController.addBill(id, availableMedicine.Name, dose, days, amount, price,DateTime.Today);
                            Console.WriteLine(id+" "+availableMedicine.Name);

                            refreshGrid();
                        }
                    }




                    drugDoseTextBox.Text = "";
                    drugNameTextBox.Text = "";

                    



                    DaysOrWeekTextBox.Text = "2";
                    WeekRadioButton.Checked = true;

                }
                else
                {
                    MessageBox.Show("Enter valid data to drug dose!");
                    drugDoseTextBox.Text = "";
                    drugNameTextBox.Text = "";
                    drugNameTextBox.Select();
                }

                drugNameTextBox.Select();
            }
        }
        public void addDeleteButton()
        {
            // Check if the button column already exists
            if (dataGridView1.Columns["RemoveButton"] == null)
            {
                DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
                removeButtonColumn.Name = "RemoveButton";
                removeButtonColumn.HeaderText = "Remove";
                removeButtonColumn.Text = "Remove";
                removeButtonColumn.UseColumnTextForButtonValue = true;

                // Add the button column at the LAST position
                dataGridView1.Columns.Add(removeButtonColumn);
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "RemoveButton")
            {
                if (e.RowIndex >= 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to remove this item?", "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Get bill details
                        int billId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                        string medicineName = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                        float amountToRestore = Convert.ToSingle(dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value);

                        // Find non-expired medicine records
                        List<Medicine> medicineList = medicineController.FindMedicineByName(medicineName)
                            .Where(m => m.ExDatee > DateTime.Today) // Exclude expired medicines
                            .OrderBy(m => m.ExDatee) // Prioritize the closest expiration date
                            .ToList();

                        if (medicineList != null && medicineList.Count > 0)
                        {
                            // Restore amount to the first non-expired stock
                            Medicine medicineToUpdate = medicineList.First();

                            if (medicineToUpdate != null)
                            {
                                medicineController.addAmount(medicineToUpdate, amountToRestore);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The medicine stock has expired. Cannot restore the amount.");
                        }

                        // Remove from the bill
                        BillModelController.removeBill(billId);

                        // Refresh DataGridView
                        refreshGrid();
                    }
                }
            }
        }



        private void refreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BillModelController.getAllBill();

            // Ensure remove button is added only once
            addDeleteButton();

            // Move RemoveButton to the last column
            dataGridView1.Columns["RemoveButton"].DisplayIndex = dataGridView1.Columns.Count - 1;
        }


        private void doneBtn_Click(object sender, EventArgs e)
        {
            String price = Convert.ToString(BillModelController.getPrice());
            MessageBox.Show("Price is " + price);
            drugNameTextBox.Select();
            dataGridView2.Visible = false;


        }

        private void drugNameTextBox_TextChanged(object sender, EventArgs e)
        {
            List<Medicine> medicines = medicineController.GetAllMedicine(); // Get original list
            string searchText = drugNameTextBox.Text.ToLower();

            // Extract only names and filter
            List<string> filteredNames = medicines
                .Where(m => m.Name.ToLower().Contains(searchText))
                .Select(m => m.Name) // Select only Name property
                .ToList();

            if (filteredNames != null) {
                dataGridView2.Visible = true;
                dataGridView2.DataSource = filteredNames
                .Select(name => new { Name = name }) // Convert to anonymous object
                .ToList();
            }

            if (filteredNames.Count > 0)
            {
                dataGridView2.DataSource = filteredNames
                    .Select(name => new { Name = name }) // Convert to anonymous object
                    .ToList();
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                
                drugNameTextBox.Text = row.Cells["Name"].Value.ToString();

                dataGridView2.Visible = false;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to continue?", "Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) { 
                
                BillModelController.clear();
                refreshGrid();
                
                drugNameTextBox.Select();
            }
        }

    }
}