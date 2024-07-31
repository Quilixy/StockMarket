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

        public async Task UpdateSystemBalance(decimal newBalance)
        {
           var systemBalance = await _context.SystemBalances.FirstOrDefaultAsync();
            if (systemBalance != null)
            {
                systemBalance.Balance = newBalance;
                _context.SystemBalances.Update(systemBalance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SystemBalance> GetSystemBalance()
        {
            return await _context.SystemBalances.FirstOrDefaultAsync();        
        }
    }
}
