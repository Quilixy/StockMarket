using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.BalanceCard
{
    public class CreateBalanceCardDto
    {
        public string Code { get; set; }
        public decimal Amount { get; set; }
    }
}