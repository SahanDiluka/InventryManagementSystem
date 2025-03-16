using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Services
{
    public class BillModelService
    {
        List<BillModel> billModels = new List<BillModel> ();

        public void add(int id, string name, float dose, int days, float amount, float price)
        {
            BillModel billModel = new BillModel (id,name,dose,days,amount,price);
            billModels.Add (billModel);
        }

        public float fullPrice()
        {
            float price = 0;
            foreach (var billModle in billModels) {

                price = billModle.Price + price;

            }
            return price;
        }

        public List<BillModel> getAll()
        {
            return billModels;
        }

        public void remove(int id)
        {
            foreach (var billModel in billModels) {

                if (billModel.Id == id) { 
                    
                    billModels.Remove (billModel);
                }
            }
        }
    }
}
