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
    public partial class ShowAllStock : UserControl
    {

        MedicineController MedicineController = new MedicineController();
        public ShowAllStock()
        {
            InitializeComponent();
            addDate();
        }

        public void addDate() { 
            
            List<Medicine> list = MedicineController.GetAllMedicine();
            List<Medicine> avalableList = new List<Medicine>();
            
            //get low stoct to up
            foreach (Medicine me in list)
            {

                if (me.Available == false && me.ExDatee >= DateTime.Today)
                {

                    avalableList.Add(me);

                }
            }
            foreach (Medicine me in list  )
            {

                if (me.Available == true && me.ExDatee >= DateTime.Today)
                {

                    avalableList.Add(me);

                }
            }




            dataGridViewStock.DataSource = avalableList;
            dataGridViewStock.Font = new Font("Arial", 14, FontStyle.Regular);
        }
    }
}
