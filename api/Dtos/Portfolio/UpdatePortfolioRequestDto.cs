using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Portfolio
{
    public class UpdatePortfolioRequestDto
    {
        public string Symbol { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}