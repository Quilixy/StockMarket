using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Portfolio;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
        {
            var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolioModel == null)
            {
                return null;
            }

            _context.Portfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;
        }

       public async Task<Portfolio> GetByUserAndSymbolAsync(string userId, string symbol)
        {
            return await _context.Portfolios
                .FirstOrDefaultAsync(p => p.AppUserId == userId && p.Stock.Symbol == symbol);
        }


        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
            .Select(stock => new Stock
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                Name = stock.Stock.Name,
                Quantity = stock.Quantity,
                Price = stock.Stock.Price
                
            }).ToListAsync();
        }

        public async Task UpdateAsync(Portfolio portfolio, UpdatePortfolioRequestDto updateDto)
        {
            portfolio.Quantity = updateDto.Quantity;
            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();
        }

    }
}