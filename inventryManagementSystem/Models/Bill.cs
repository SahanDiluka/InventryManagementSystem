using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventryManagementSystem.Models
{
    public class Bill
    {
        public Bill(int id, float price, DateTime date)
        {
            Id = id;
            this.price = price;
            this.date = date;
        }

        public int Id { get; set; }
        public float price { get; set; }
        public DateTime date { get; set; }
    }
}
