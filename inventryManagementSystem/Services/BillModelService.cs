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

        MedicineDatabase medicineDatabase = new MedicineDatabase();
       static BillDatabase billDatabase = new BillDatabase();

        static List<BillModel> sumBillModels = billDatabase.GetAllBills();
        List<BillModel> billModels = new List<BillModel>();

        public BillModelService() { 
            billDatabase.DeleteOldBills();
        }

        public void add(int id, string name, float dose, int days, float amount, float price, DateTime date)
        {
            BillModel billModel = new BillModel (id,name,dose,days,amount,price,date);
            
            billDatabase.AddBill(id, name, dose, days, amount, price, date);
            billModels.Add (billModel);
            Console.WriteLine(billModel);

            sumBillModels.Add (billModel);
            
        }

        public float fullPrice()
        {
            float price = 0;

            if (billModels.Equals(null))
            {
                return 0;
            }
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
            for (int i = billModels.Count - 1; i >= 0; i--)
            {
                if (billModels[i].Id == id)
                {
                    var item = billModels[i]; 
                    billModels.RemoveAt(i);   
                    sumBillModels.Remove(item); 
                    billDatabase.RemoveBillById(id); 
                }
            }
        }


        public List<BillModel> getAllsummary()
        {
            return sumBillModels;
        }

        public void clear() {
            billModels.Clear();
        }

        public int GetMaxBillId()
        {
            List<BillModel> bills = getAllsummary();

            if (bills == null || bills.Count == 0)
            {
                return 1000; // Default starting ID if the list is empty
            }

            return bills.Max(b => b.Id);
        }


      

    }
}
