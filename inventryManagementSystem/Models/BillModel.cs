using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventryManagementSystem.Models
{
    public class BillModel
    {
        public BillModel(int id, string name, float dose, int days, float amount, float price, DateTime date)
        {
            Id = id;
            Name = name;
            Dose = dose;
            Days = days;
            Amount = amount;
            Price = price;
            Date = date;  
        }

      
        public int Id { get; set; }
        public string Name { get; set; }
        public float Dose { get; set; }
        public int Days { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }


    }
}
