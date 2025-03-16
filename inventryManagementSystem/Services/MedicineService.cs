using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Services
{
    public class MedicineService
    {

        //making only one time so dont need to create evry time
        private  static List<Medicine> medicines = new MedicineRecords().GetAllMedicines();


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

        public Medicine GetMedicineByName(string name)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name == name)
                {
                    return medicine;
                }
            }
            return null;
        }

        public void Remove(int id)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id)
                {
                    medicines.Remove(medicine);
                }
            }
        
        }

        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id)
                {
                    medicines.Equals(updatedMedicine);
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
                }
            }
        }

        public void Create(int id, string name, float dose, string companyName, DateTime exDate, DateTime manufacturedDate, float amount,float price)
        {
            Medicine medicine = new Medicine(id,name,dose,companyName,exDate,manufacturedDate,amount, price);
            medicines.Add(medicine);
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

        public void setAmount(String name,float amount)
        {
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    Console.WriteLine(amount);

                    float amut = medicine.Amount;
                    Console.WriteLine( "stock amount" + amut);
                    medicine.Amount = amut - amount;

                    Console.WriteLine(amut - amount);
                    Console.WriteLine(medicine.Amount);

                    if (medicine.Amount <= 0) {
                        medicine.Amount = 0;
                    }
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
                }
                
            }
        }

        
    }           
    
}
