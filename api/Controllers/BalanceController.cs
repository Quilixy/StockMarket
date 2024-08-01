using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/balance")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;
        private readonly UserManager<AppUser> _userManager;

        public BalanceController(UserManager<AppUser> userManager, IBalanceService balanceService)
        {
            _balanceService = balanceService;
            _userManager = userManager;
        }

        // GET api/balance
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBalance()
        {
            //var username = User.FindFirstValue(ClaimTypes.Name);
            var username = User.GetUsername();
            var user = await _balanceService.GetUserByUsername(username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(new { Balance = user.Balance });
        }

        // PUT api/balance
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBalance([FromBody] UpdateBalanceDto updateBalanceDto)
        {
            //var username = User.FindFirstValue(ClaimTypes.Name);
            var username = User.GetUsername();
            var user = await _balanceService.GetUserByUsername(username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            await _balanceService.UpdateUserBalance(user.Id, updateBalanceDto.NewBalance);

            return NoContent();
        }

        [HttpGet("system")]
        [Authorize (Roles = "Admin")] //(Roles = "ADMIN")
        public async Task<IActionResult> GetSystemBalance()
        {
            var systemBalance = await _balanceService.GetSystemBalance();
            if (systemBalance == null)
            {
                return NotFound("System balance not found");
            }

            return Ok(new { Balance = systemBalance.Balance });
        }

        [HttpPut("system")]
        [Authorize(Roles = "Admin")] //(Roles = "Admin")
        public async Task<IActionResult> UpdateSystemBalance([FromBody] UpdateBalanceDto updateBalanceDto)
        {
            await _balanceService.UpdateSystemBalance(updateBalanceDto.NewBalance);
            return NoContent();
        }
    
    }
}
