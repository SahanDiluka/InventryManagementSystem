using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Services
{
    public class MedicineService
    {
        private List<Medicine> medicines = new MedicineRecords().GetAllMedicines();

        public List<Medicine> GetAll()
        {
            return medicines;
        }

        public Medicine GetMedicineById(int id)
        {
            throw new NotImplementedException();
        }

        public Medicine GetMedicineByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMedicine(int id, Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void UpdateMedicine(String name, Medicine medicine)
        {
            throw new NotImplementedException();
        }

        internal void Create(int id, string name, float dose, string companyName, DateTime exDate, DateTime manufacturedDate, int amount)
        {
            throw new NotImplementedException();
        }

        internal int getAmount(int id)
        {
            throw new NotImplementedException();
        }

        internal DateTime getExpiredDate(int id)
        {
            throw new NotImplementedException();
        }

        internal float getPrice(int id)
        {
            throw new NotImplementedException();
        }
    }
}
