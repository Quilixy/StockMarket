using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Transaction
{
    public class TransactionDto
    {
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPurchase { get; set; }
        public DateTime Date { get; set; }
    }
}