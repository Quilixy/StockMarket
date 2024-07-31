using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Portfolio;
using api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> GetByUserAndSymbolAsync(string userId, string symbol);
        Task<List<Stock>> GetUserPortfolio(AppUser user);
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task UpdateAsync(Portfolio portfolio, UpdatePortfolioRequestDto updateDto);
        Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol);
    }
}