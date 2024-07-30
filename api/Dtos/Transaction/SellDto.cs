using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Transaction
{
    public class SellDto
    {
        public string Symbol { get; set; }
        public int Quantity { get; set; }

    }
}