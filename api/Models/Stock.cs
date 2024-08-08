using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Stocks")]
    public class Stock
    {
        public int Id {get; set;}
        public string Symbol {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
        public int Quantity {get; set;} = 10000;
        public decimal Price {get; set;}
        public bool IsTradingHalted { get; set; }
        public List<Portfolio> Portfolios {get; set;} = new List<Portfolio>();
    }
}