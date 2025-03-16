using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventryManagementSystem.Models
{
    public class Medicine
    {
        private int id;
        private String name;
        private float dose;
        private String companyName;
        private DateTime exDatee;
        private DateTime manufacturedDate;
        private bool available;
        private float amount;
        private float price;

        public Medicine(int id, string name, float dose, string companyName, DateTime exDatee, DateTime manufacturedDate, float amount, float price)
        {
            this.id = id;
            this.name = name;
            this.dose = dose;
            this.companyName = companyName;
            this.exDatee = exDatee;
            this.manufacturedDate = manufacturedDate;
            this.available = true;
            this.amount = amount;
            this.price = price;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float Dose
        {
            get { return dose; }
            set { dose = value; }
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public DateTime ExDatee
        {
            get { return exDatee; }
            set { exDatee = value; }
        }

        public DateTime ManufacturedDate
        {
            get { return manufacturedDate; }
            set { manufacturedDate = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

    }
}
