using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public decimal Balance { get; set; } = 0;
        public List<Portfolio> Portfolios {get; set;} = new List<Portfolio>();
        
    }
}