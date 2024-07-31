using api.Interfaces;
using api.Models;
using System.Threading.Tasks;

namespace api.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceService(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        


        public async Task<AppUser> GetUserByUsername(string username)
        {
            return await _balanceRepository.GetUserByUsername(username);
        }


        public async Task UpdateUserBalance(string userId, decimal newBalance)
        {
            var user = await _balanceRepository.GetUserById(userId);
            if (user != null)
            {
                user.Balance = newBalance;
                await _balanceRepository.UpdateUserBalance(user);
            }
        }
        public async Task UpdateSystemBalance(decimal newBalance)
        {
             var systemBalance = await _balanceRepository.GetSystemBalance();
            if (systemBalance != null)
            {
                systemBalance.Balance = newBalance;
                await _balanceRepository.UpdateSystemBalance(systemBalance);
            }
            else
            {
                systemBalance = new SystemBalance { Balance = newBalance };
                await _balanceRepository.UpdateSystemBalance(systemBalance);
            }
        }
        public async Task<SystemBalance> GetSystemBalance()
        {
            //return await _balanceRepository.GetSystemBalance();
            var systemBalance = await _balanceRepository.GetSystemBalance();
            if (systemBalance == null)
            {
                systemBalance = new SystemBalance { Balance = 0 };
                await _balanceRepository.UpdateSystemBalance(systemBalance);
            }
            return systemBalance;
        }
    }
}