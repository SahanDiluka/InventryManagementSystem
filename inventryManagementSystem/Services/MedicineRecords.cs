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
            

            Medicine med1 = new Medicine(001, "Paracetamol", 20f, "ABC Pharma",
                                         new DateTime(2025, 12, 31), new DateTime(2023, 06, 15), 100, 10);

            Medicine med2 = new Medicine(002, "Ibuprofen", 200f, "XYZ Meds",
                                         new DateTime(2025, 03, 16), new DateTime(2025, 03, 16), 500, 10);

            Medicine med3 = new Medicine(003, "Amoxicillin", 250f, "HealthCare Inc.",
                                         new DateTime(2025, 03, 18), new DateTime(2023, 11, 01), 50, 10);

            Medicine med4 = new Medicine(004, "Aspirin", 50f, "MediCorp",
                                         new DateTime(2025, 03, 12), new DateTime(2024, 02, 10), 200, 10);

            Medicine med5 = new Medicine(005, "Cetirizine", 30f, "ABC Pharma",
                                         new DateTime(2025, 10, 20), new DateTime(2023, 05, 25), 50, 10);

            Medicine med6 = new Medicine(006, "Loratadine", 40f, "XYZ Meds",
                                         new DateTime(2027, 03, 10), new DateTime(2024, 04, 12), 10, 10);

            Medicine med7 = new Medicine(007, "Metformin", 500f, "MediCare",
                                         new DateTime(2025, 09, 05), new DateTime(2023, 07, 19), 30, 10);

            Medicine med8 = new Medicine(008, "Atorvastatin", 300f, "HealthLife",
                                         new DateTime(2026, 11, 20), new DateTime(2024, 06, 11), 70, 10);

            Medicine med9 = new Medicine(009, "Losartan", 100f, "PharmaPlus",
                                         new DateTime(2027, 02, 18), new DateTime(2024, 08, 23), 90, 10);

            Medicine med10 = new Medicine(010, "Omeprazole", 150f, "ABC Pharma",
                                          new DateTime(2025, 12, 25), new DateTime(2023, 10, 14), 40, 10);

            Medicine med11 = new Medicine(011, "Ranitidine", 80f, "XYZ Meds",
                                          new DateTime(2026, 06, 15), new DateTime(2024, 09, 05), 60, 10);

            Medicine med12 = new Medicine(012, "Prednisolone", 120f, "MediCorp",
                                          new DateTime(2025, 04, 10), new DateTime(2023, 11, 02), 25, 10);

            Medicine med13 = new Medicine(013, "Salbutamol", 250f, "HealthCare Inc.",
                                          new DateTime(2026, 08, 22), new DateTime(2024, 01, 15), 15, 10);

            Medicine med14 = new Medicine(014, "Dextromethorphan", 90f, "MediCare",
                                          new DateTime(2027, 05, 30), new DateTime(2024, 12, 01), 80, 10);

            Medicine med15 = new Medicine(015, "Codeine", 180f, "PharmaPlus",
                                          new DateTime(2025, 07, 10), new DateTime(2023, 03, 20), 55, 10);

            Medicine med16 = new Medicine(016, "Acetaminophen", 250f, "ABC Pharma",
                                          new DateTime(2026, 09, 15), new DateTime(2024, 02, 12), 10, 10);

            Medicine med17 = new Medicine(017, "Hydroxyzine", 350f, "XYZ Meds",
                                          new DateTime(2027, 11, 05), new DateTime(2024, 07, 22), 5, 10);

            Medicine med18 = new Medicine(018, "Benzonatate", 130f, "MediCorp",
                                          new DateTime(2025, 06, 20), new DateTime(2023, 10, 25), 35, 10);

            Medicine med19 = new Medicine(019, "Cetirizine", 40f, "HealthLife",
                                          new DateTime(2026, 12, 18), new DateTime(2024, 03, 30), 20, 10);

            Medicine med20 = new Medicine(020, "Ibuprofen", 300f, "PharmaPlus",
                                          new DateTime(2027, 04, 22), new DateTime(2024, 05, 01), 75, 10);

            // Add all medicines to the list
            medicineList.Add(med1);
            medicineList.Add(med2);
            medicineList.Add(med3);
            medicineList.Add(med4);
            medicineList.Add(med5);
            medicineList.Add(med6);
            medicineList.Add(med7);
            medicineList.Add(med8);
            medicineList.Add(med9);
            medicineList.Add(med10);
            medicineList.Add(med11);
            medicineList.Add(med12);
            medicineList.Add(med13);
            medicineList.Add(med14);
            medicineList.Add(med15);
            medicineList.Add(med16);
            medicineList.Add(med17);
            medicineList.Add(med18);
            medicineList.Add(med19);
            medicineList.Add(med20);

        }


        public List<Medicine> GetAllMedicines()
        {
            return medicineList;
        }

    }
}
