using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api.Services
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly ApplicationDBContext _context;

        public BalanceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        


        public async Task<AppUser> GetUserById(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<AppUser> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

       

        public async Task UpdateUserBalance(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSystemBalance(SystemBalance systemBalance)
        {
           var existingSystemBalance = await GetSystemBalance();
            if (existingSystemBalance != null)
            {
                existingSystemBalance.Balance = systemBalance.Balance;
                _context.SystemBalances.Update(existingSystemBalance);
            }
            else
            {
                await _context.SystemBalances.AddAsync(systemBalance);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<SystemBalance> GetSystemBalance()
        {
            return await _context.SystemBalances.FirstOrDefaultAsync();        
        }

       

    }
}
