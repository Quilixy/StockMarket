using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class SystemBalance
    {
        public int Id { get; set; }
        public decimal Balance { get; set; } = 0;
    }
}