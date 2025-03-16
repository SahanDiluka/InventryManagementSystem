using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using inventryManagementSystem.Controllers;

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

                    medicineController.setamount(name.Trim(), amount);//dosent work

                    Console.WriteLine(name);
                    Console.WriteLine(amount);

                    BillModelController.addBill(id, name, dose, days, amount, price);



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