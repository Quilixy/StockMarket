using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BalanceCard;

namespace api.Interfaces
{
    public interface IBalanceCardService
    {
        Task CreateBalanceCard(CreateBalanceCardDto createBalanceCardDto);
        Task UseBalanceCard(string code, string userId);
    }
    
}