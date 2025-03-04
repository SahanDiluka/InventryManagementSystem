using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventryManagementSystem.Models
{
    public class BillModel
    {
        public BillModel(int id, string name, float dose, int days, int amount, float price)
        {
            Id = id;
            Name = name;
            Dose = dose;
            Days = days;
            Amount = amount;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Dose { get; set; }
        public int Days { get; set; }
        public int Amount { get; set; }
        public float Price {  get; set; }


    }
}
