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
using inventryManagementSystem.Services;

namespace inventryManagementSystem.Views
{
    public partial class Summary : UserControl
    {
        BillModelController modelController = new BillModelController();
        public Summary()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = modelController.getAllsummary();
            dataGridView1.Font = new Font("Arial", 14, FontStyle.Regular);
            
        }
    }

}

    
