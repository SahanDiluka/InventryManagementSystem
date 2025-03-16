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

    
    public partial class ShowLowStock : UserControl
    {

        MedicineController MedicineController = new MedicineController();
        public ShowLowStock()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData() { 
            List<Medicine> medicines = MedicineController.GetAllMedicine();

            List<Medicine> notAavalble = new List<Medicine> { };

            foreach (Medicine me in medicines) {
                if (me.Amount <= 30) { 
                    notAavalble.Add(me);
                }
            }


            dataGridViewLowStock.DataSource = notAavalble;
            dataGridViewLowStock.Font = new Font("Arial", 14, FontStyle.Regular);
        } 
    }
}
