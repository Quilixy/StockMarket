using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface ICommissionService
    {
        decimal GetCommissionRate();
        void UpdateCommissionRate(decimal newRate);
    }
}