using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using inventryManagementSystem.Views;

namespace inventryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            startUp();
        }

        public void startUp() {
            loadPanle.BringToFront();
            addBIll AddBIll = new addBIll();
            AddBIll.Dock = DockStyle.Fill;
            AddBIll.Dock = DockStyle.Fill;
            loadPanle.Controls.Add(AddBIll);
        }

        private void billingBtn_Click(object sender, EventArgs e)
        {
            loadPanle.Controls.Clear();
            loadPanle.BringToFront();
            addBIll AddBIll = new addBIll();
            AddBIll.Dock = DockStyle.Fill;
            loadPanle.Controls.Add(AddBIll);
            sidePanale.Location = new Point(0, 90);
        }

        private void checkStockBtn_Click(object sender, EventArgs e)
        {
            loadPanle.Controls.Clear();
            loadPanle.BringToFront();
            ShowAllStock showAllStock = new ShowAllStock();
            showAllStock.Dock = DockStyle.Fill;
            loadPanle.Controls.Add(showAllStock);
            
            sidePanale.Location = new Point(0, 155);
        }

        private void lowStockBtn_Click(object sender, EventArgs e)
        {

            loadPanle.Controls.Clear();
            loadPanle.BringToFront();
            ShowLowStock showLowStock = new ShowLowStock();
            showLowStock.Dock = DockStyle.Fill;
            loadPanle.Controls.Add(showLowStock);

            sidePanale.Location = new Point(0, 340);
        }

        private void exDateBtn_Click(object sender, EventArgs e)
        {

            loadPanle.Controls.Clear();
            loadPanle.BringToFront();
            ExpiredDate expiredDate = new ExpiredDate();
            expiredDate.Dock = DockStyle.Fill;
            loadPanle.Controls.Add(expiredDate);

            sidePanale.Location = new Point(0, 280);
        }

       
    }
}
