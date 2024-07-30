using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPurchase { get; set; }
        public DateTime Date { get; set; }
    }
}