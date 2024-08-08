using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class StockPriceHistoryDto
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}