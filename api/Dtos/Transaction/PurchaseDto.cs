using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Transaction
{
    public class PurchaseDto
    {
        public string Symbol { get; set; }
        public int Quantity { get; set; }
    }
}