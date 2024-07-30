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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;

        public TransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetUserTransactionsAsync(string userId)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }
    }
}