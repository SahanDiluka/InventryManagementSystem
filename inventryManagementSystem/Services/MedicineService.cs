using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Services
{
    public class MedicineService
    {

        //making only one time so dont need to create evry time
        MedicineDatabase MedicineDatabase  = new MedicineDatabase();
        private  static List<Medicine> medicines = MedicineDatabase.GetAllMedicines();


        public MedicineService() {
            setAvailability();
            
            
        }
        public List<Medicine> GetAll()
        {
            return medicines;
        }

        public Medicine GetMedicineById(int id)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id) {  
                    return medicine;
                }
            }
            return null;
        }

        public List<Medicine> GetMedicineByName(string name)
        {  
            List<Medicine> list = new List<Medicine>();
            
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name == name)
                {
                    list.Add(medicine);
                }
            }
            return list;
        }

        public void Remove(int id)
        {
            for (int i = 0; i < medicines.Count; i++)
            {
                if (medicines[i].Id == id)
                {
                    medicines.RemoveAt(i);
                    MedicineDatabase.DeleteMedicineById(id);
                    // Adjust the index because the collection is now shorter
                    i--;
                }
            }
        }


        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id)
                {

                    MedicineDatabase.UpdateMedicineById(id, updatedMedicine);
                }
            }
        }

        public void UpdateMedicine(String name, Medicine updatedMedicine)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name == name)
                {
                    medicines.Equals(updatedMedicine);
                    MedicineDatabase.UpdateMedicineByName(name, updatedMedicine);
                }
            }
        }

        public void Create(int id, string name, float dose, string companyName, DateTime exDate, DateTime manufacturedDate, float amount,float price)
        {
            Medicine medicine = new Medicine(id,name,dose,companyName,exDate,manufacturedDate,amount, price);
            medicines.Add(medicine);
            MedicineDatabase.Create(id, name, dose, companyName, exDate, manufacturedDate, amount, price);
        }
        public Medicine CreateOne(int id, string name, float dose, string companyName, DateTime exDate, DateTime manufacturedDate, float amount, float price)
        {
            Medicine medicine = new Medicine(id, name, dose, companyName, exDate, manufacturedDate, amount, price);
             return medicine;
        }

        public float getAmount(int id)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id)
                {
                    return medicine.Amount;
                }
            }
            return 0;
        }

        public void setAmount(Medicine medicine,float amount)
        {
            int i = 0;

            foreach (Medicine med in medicines)
            {
                if (medicine.Equals(med))
                {

                    if (med.Amount < 0) { 
                        med.Amount = amount;
                    }
                   
                float amut = medicine.Amount;
                float newAmount = amut - amount;
                 medicine.Amount = newAmount;

                MedicineDatabase.UpdateMedicineAmount(medicine.Id,newAmount);
                i++; 

                }
            }

            MedicineService service = new MedicineService();
            service.setAvailability();
            
        }

        public DateTime getExpiredDate(int id)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id)
                {
                    return medicine.ExDatee;
                }
            }
            return new DateTime(0,0,0);
        }

        public float getPrice(String name)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    return medicine.Price;
                }
            }
            return 0;
        }

        public float getDose(string name)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    return medicine.Dose;
                }
            }
            return 0;
        }

        public List<Medicine> getMedicineByName(string name)
        {
            //List Name = string.Format("Convert(Medicine, 'System.String') LIKE '%{0}%'", name);
            List<Medicine> values = new List<Medicine>();
            return values;
        }

       public void setAvailability()
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Amount <= 30 || medicine.ExDatee <= DateTime.Today)
                {
                    medicine.Available=false;
                    MedicineDatabase.UpdateMedicineAvailability(medicine.Id,false);
                }
                
            }
        }

        public int getMAxId()
        {
           if(medicines.Count == 0)
            {
                return 0;
            }

           return medicines.Max(m => m.Id);
        }

        public bool checkIfEqual(Medicine me)
        {
            foreach(Medicine med in medicines)
            {
                if(me.Id == med.Id && me.Name.Equals(med.Name) && me.Dose == med.Dose && 
                    me.ExDatee == med.ExDatee && me.ManufacturedDate == med.ManufacturedDate &&
                    me.Price == med.Price)
                {
                    return true;
                }

            }

            return false;
        }

        public void addAmount(Medicine medicine, float amount)
        {
            medicine.Amount += amount; // Add back the amount
            MedicineDatabase.UpdateMedicineById(medicine.Id, medicine);  // Save changes to database
        }
    }           
    
}
