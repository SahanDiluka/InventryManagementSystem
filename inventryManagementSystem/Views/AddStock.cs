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
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Views
{
    public partial class AddStock : UserControl
    {
        MedicineController medicineController; 
        List<Medicine> medicines; 

        public AddStock()
        {
            InitializeComponent();

            medicineController = new MedicineController(); 
            medicines = medicineController.GetAllMedicine();

            this.Load += addStock_Load;
            
            
        }

        private void addStock_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() => drugNameTextBox.Focus()));
        }

        public void addData() { 
           
            

            if (string.IsNullOrWhiteSpace(drugDoseTextBox.Text)|| string.IsNullOrWhiteSpace(drugNameTextBox.Text) || string.IsNullOrWhiteSpace(manufacuredDateTextBox.Text)||
                string.IsNullOrWhiteSpace(expiredDateTextBox.Text) || string.IsNullOrWhiteSpace(companyNameTextBox.Text) || string.IsNullOrWhiteSpace(amountTextBox.Text)||
                string.IsNullOrWhiteSpace(priceTextBox.Text) )
            {
                MessageBox.Show("Enter all the data!");
            }

            else
            {
                int maxId = medicineController.getMaxId();

                int id = maxId + 1;

                String name = drugNameTextBox.Text;

                float dose;
                String companyName = companyNameTextBox.Text;

                DateTime exDate;

                DateTime manDate;

                float price;

                float amount;

                if (!float.TryParse(drugDoseTextBox.Text, out dose))
                {
                    MessageBox.Show("Enter valid drug dose");
                    drugDoseTextBox.Text = "";
                }
                if (!DateTime.TryParse(expiredDateTextBox.Text, out exDate))
                {
                    MessageBox.Show("Enter Valid date");
                    expiredDateTextBox.Text = "";
                }


     
                if (!DateTime.TryParse(manufacuredDateTextBox.Text, out manDate))
                {
                    MessageBox.Show("Enter Valid date");
                    manufacuredDateTextBox.Text = "";
                }

               if (!float.TryParse(priceTextBox.Text, out price))
                {
                    MessageBox.Show("Enter valid drug price");
                    priceTextBox.Text = "";
                }

               
               if (!float.TryParse(amountTextBox.Text, out amount))
                {
                    MessageBox.Show("Enter valid drug amount");
                    amountTextBox.Text = "";
                }

                Medicine existingMedicine = medicines.FirstOrDefault(m => m.Name == name && m.Dose == dose && m.CompanyName == companyName&& m.Price == price && m.ManufacturedDate == manDate && m.ExDatee ==exDate);

                if (existingMedicine != null)
                {
                    existingMedicine.Amount += amount; // Add new stock to existing stock

                    medicineController.UpdateMedicineById(existingMedicine.Id,existingMedicine);
                    MessageBox.Show("Medicine stock updated successfully!");
                }
                else {
                   
                    medicineController.CreateMedicine(id, name.ToLower(), dose, companyName.ToLower(), exDate, manDate, amount, price);
                    MessageBox.Show("Data added sucussfully!");
                    drugNameTextBox.Select();
                    clearTextBoxes();
                
                }
                
            }
        }


        public void clearTextBoxes()
        {
            drugDoseTextBox.Text = "";
            drugNameTextBox.Text = "";
            companyNameTextBox.Text = "";
            expiredDateTextBox.Text = "";
            manufacuredDateTextBox.Text = "";
            amountTextBox.Text = "";
            priceTextBox.Text = "";
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            addData();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
            drugNameTextBox.Select();
        }

        private void drugNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                drugDoseTextBox.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void drugDoseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                companyNameTextBox.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void companyNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                expiredDateTextBox.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void expiredDateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                manufacuredDateTextBox.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void manufacuredDateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                amountTextBox.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void amountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                priceTextBox.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void priceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doneBtn.PerformClick();
               
            }
        }
    }
}
