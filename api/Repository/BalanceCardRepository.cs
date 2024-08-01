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
    public class BalanceCardRepository : IBalanceCardRepository
    {
        private readonly ApplicationDBContext _context;

        public BalanceCardRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BalanceCard> GetBalanceCardByCode(string code)
        {
            return await _context.BalanceCards
                .FirstOrDefaultAsync(bc => bc.Code == code);
        }

        public async Task CreateBalanceCard(BalanceCard balanceCard)
        {
            await _context.BalanceCards.AddAsync(balanceCard);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBalanceCard(BalanceCard balanceCard)
        {
            _context.BalanceCards.Update(balanceCard);
            await _context.SaveChangesAsync();
        }
    }
}