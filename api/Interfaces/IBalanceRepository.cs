using api.Models;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IBalanceRepository
    {
        Task<AppUser> GetUserById(string userId);
        Task<AppUser> GetUserByUsername(string username);
        Task UpdateUserBalance(AppUser user);
        Task<SystemBalance> GetSystemBalance();
        Task UpdateSystemBalance(decimal newBalance);
    }
}
