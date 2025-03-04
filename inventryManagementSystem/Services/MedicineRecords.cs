using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventryManagementSystem.Models;

namespace inventryManagementSystem.Services
{
    public class MedicineRecords
    {

        private List<Medicine> medicineList = new List<Medicine>();

        public MedicineRecords()
        {
            Medicine med1 = new Medicine(001, "Paracetamol", 500f, "ABC Pharma",
                                         new DateTime(2025, 12, 31), new DateTime(2023, 06, 15), 100);

            Medicine med2 = new Medicine(002, "Ibuprofen", 200f, "XYZ Meds",
                                         new DateTime(2026, 05, 20), new DateTime(2024, 01, 10), 50);

            Medicine med3 = new Medicine(003, "Amoxicillin", 250f, "HealthCare Inc.",
                                         new DateTime(2025, 08, 12), new DateTime(2023, 11, 01), 75);

            medicineList.Add(med1);
            medicineList.Add(med2);
            medicineList.Add(med3);
        }


        public List<Medicine> GetAllMedicines()
        {
            return medicineList;
        }

    }
}
