using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStockPriceHistoryRepository
    {
        Task<IEnumerable<StockPriceHistory>> GetByStockIdAsync(int stockId);
        Task<StockPriceHistory> AddAsync(StockPriceHistory history);
    }
}