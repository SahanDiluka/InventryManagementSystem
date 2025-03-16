using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventryManagementSystem.Models;
using inventryManagementSystem.Services;

namespace inventryManagementSystem.Controllers
{
    public class MedicineController
    {
        private MedicineService medicineService = new MedicineService();


        public List<Medicine> GetAllMedicine()
        {
            return medicineService.GetAll();
        }
        public void CreateMedicine(int id, string name, float dose, string companyName, DateTime exDate, DateTime manufacturedDate, int amount,float price)
        {
            medicineService.Create(id,name,dose,companyName,exDate,manufacturedDate,amount,price);
        }
        public Medicine FindMedicineById(int id)
        {
            return medicineService.GetMedicineById(id);
        }

        public Medicine FindMedicineByName(String Name)
        {
            return medicineService.GetMedicineByName(Name);
        }
        
        public void UpdateMedicineById(int id, Medicine medicine)
        {
            medicineService.UpdateMedicine(id, medicine);
        }

        public void UpdateMedicineByName(String name, Medicine medicine)
        {
            medicineService.UpdateMedicine(name, medicine);
        }

        public void RemoveMedicine(int id)
        {
            medicineService.Remove(id);
        }

        public float GetMedicinePrice(String name) 
        { 
            return medicineService.getPrice(name);
        }
        public float GetMedicineDose(String name)
        {
            return medicineService.getDose(name);
        }
        public DateTime GetMedicineExpiredDate(int id) 
        {
            return medicineService.getExpiredDate(id);
        }

        public float GetMedicineAmount(int id)
        {
            return medicineService.getAmount(id);
        }
        public List<Medicine> GetMedicineByName(String name)
        {
            return medicineService.getMedicineByName(name);
        }

        public void setamount(String name,float amount) {
            medicineService.setAmount(name,amount);
        }
    }
}