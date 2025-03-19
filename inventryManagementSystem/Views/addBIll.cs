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




        }

        public void startUpDataGridView() {
            DaysOrWeekTextBox.Text = "2";
            WeekRadioButton.Checked = true;

        }

        private void addMoreBtn_Click(object sender, EventArgs e)
        {
            
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //check value for null or empty spaces
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

                    int id = 0000 + i;
                    i++;

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
                    }
                    else
                    {
                        Medicine availableMedicine = list.FirstOrDefault(n => n.Amount > amount && n.ExDatee > DateTime.Today && n.Amount > 30);

                        if (availableMedicine == null)
                        {
                            MessageBox.Show("This drug is either out of stock or expired!");
                        }
                        else
                        {
                            medicineController.setamount(availableMedicine, amount);
                            BillModelController.addBill(id, availableMedicine.Name, dose, days, amount, price);
                        }
                    }




                    drugDoseTextBox.Text = "";
                    drugNameTextBox.Text = "";

                    dataGridView1.DataSource = null;

                    
                    dataGridView1.DataSource = BillModelController.getAllBill();



                    DaysOrWeekTextBox.Text = "2";
                    WeekRadioButton.Checked = true;

                }
                else
                {
                    MessageBox.Show("Enter valid data to drug dose!");
                    drugDoseTextBox.Text = "";
                    drugNameTextBox.Text = "";
                }

               
            }
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            String price = Convert.ToString(BillModelController.getPrice());
            MessageBox.Show("Price is " + price);
          
        }

        
    }
}