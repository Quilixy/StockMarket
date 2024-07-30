using api.Models;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IBalanceService
    {
        Task<AppUser> GetUserByUsername(string username);
        Task UpdateUserBalance(string userId, decimal newBalance);
    }
}
