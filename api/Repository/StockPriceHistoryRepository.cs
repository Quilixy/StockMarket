using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockPriceHistoryRepository : IStockPriceHistoryRepository
    {
        private readonly ApplicationDBContext _context;

        public StockPriceHistoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockPriceHistory>> GetByStockIdAsync(int stockId)
        {
            return await _context.StockPriceHistories
                .Where(h => h.StockId == stockId)
                .OrderByDescending(h => h.Date)
                .ToListAsync();
        }

        public async Task<StockPriceHistory> AddAsync(StockPriceHistory history)
        {
            _context.StockPriceHistories.Add(history);
            await _context.SaveChangesAsync();
            return history;
        }
    }

}