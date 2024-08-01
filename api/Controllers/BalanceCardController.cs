using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.BalanceCard;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
   [ApiController]
    [Route("api/balancecard")]
    public class BalanceCardController : ControllerBase
    {
        private readonly IBalanceCardService _balanceCardService;
        public BalanceCardController(IBalanceCardService balanceCardService)
        {
            _balanceCardService = balanceCardService;
            
        }

        [HttpPost]
        [Authorize] //(Policy = "AdminOnly")
        public async Task<IActionResult> CreateBalanceCard([FromBody] CreateBalanceCardDto createBalanceCardDto)
        {
            await _balanceCardService.CreateBalanceCard(createBalanceCardDto);
            return NoContent();
        }

        [HttpPost("use")]
        [Authorize]
       public async Task<IActionResult> UseBalanceCard([FromBody] UseBalanceCardDto useBalanceCardDto)
        {
            var username = User.GetUsername(); 
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Username is not found.");
            }

            try
            {
                await _balanceCardService.UseBalanceCard(useBalanceCardDto.Code, username);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message); // Hatanın daha iyi anlaşılması için
            }
        }
    }
}