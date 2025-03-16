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
    public partial class ExpiredDate : UserControl
    {
        MedicineController MedicineController = new MedicineController();
        public ExpiredDate()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData() {

            DateTime today = DateTime.Today;
            DateTime fifteenDaysAbove = today.AddDays(15);

            List<Medicine> medicines = MedicineController.GetAllMedicine();
            List<Medicine> nearExpiredDate = new List<Medicine>();


            foreach (Medicine me in medicines) {

                if (me.ExDatee <= fifteenDaysAbove && me.Available == false)
                {
                    nearExpiredDate.Add(me);
                }


            }
            foreach (Medicine me in medicines)
            {

                if (me.ExDatee <= fifteenDaysAbove && me.Available == true)
                {
                    nearExpiredDate.Add(me);
                }


            }

            dataGridViewExpiredDate.DataSource = nearExpiredDate;
            dataGridViewExpiredDate.Font = new Font("Arial", 14, FontStyle.Regular);

        }
    }
}
