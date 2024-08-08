using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StockPriceHistory
    {
        public int Id { get; set; }
        public int StockId { get; set; } 
        public DateTime Date { get; set; } 
        public decimal Price { get; set; } 
        public Stock Stock { get; set; }

    }
}