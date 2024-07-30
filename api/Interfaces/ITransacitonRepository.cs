using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        Task CreateAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetUserTransactionsAsync(string userId);
    }
}