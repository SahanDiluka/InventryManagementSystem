using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventryManagementSystem.Models;
using inventryManagementSystem.Services;

namespace inventryManagementSystem.Controllers
{
    public class BillModelController
    {   
        BillModelService billModelService = new BillModelService();
        public List<BillModel> getAllBill() {

            return billModelService.getAll();
        }

        public void addBill(int id, string name, float dose, int days, float amount, float price,DateTime date) {
            billModelService.add(id,  name,  dose, days,  amount, price,date);
        }

        public void removeBill(int id) {
            billModelService.remove(id);
        }

        public float getPrice() {
            return billModelService.fullPrice();
        }
        public List<BillModel> getAllsummary()
        {
            return billModelService.getAllsummary();
        }
        public void clear() { 
            billModelService.clear();
        }

        public int getMaxId()
        {
            return billModelService.GetMaxBillId();
        }

        
    }
}
