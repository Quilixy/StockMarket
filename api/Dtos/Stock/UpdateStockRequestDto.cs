using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        public int Id {get; set;}
        public string Symbol {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
        public int Quantity {get; set;}
        public decimal Price {get; set;}
    }
}