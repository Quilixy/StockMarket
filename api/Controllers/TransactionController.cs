using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Dtos.Transaction;
using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly ITransactionRepository _transactionRepo;
        private readonly decimal _commissionRate = 0.05m; // %5 komisyon

        public TransactionController(UserManager<AppUser> userManager,
        IStockRepository stockRepo,
        ITransactionRepository transactionRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _transactionRepo = transactionRepo;
        }

        [HttpPost("purchase")]
        [Authorize]
        public async Task<IActionResult> Purchase([FromBody] PurchaseDto request)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var stock = await _stockRepo.GetBySymbolAsync(request.Symbol);
            if (stock == null) return BadRequest("Stock not found");

            decimal totalCost = request.Quantity * stock.Price;
            decimal commission = totalCost * _commissionRate;
            decimal totalAmount = totalCost + commission;

            if (appUser.Balance < totalAmount)
                return BadRequest("Insufficient balance");

            appUser.Balance -= totalAmount;
            stock.Quantity -= request.Quantity;

            var transaction = new Transaction
            {
                UserId = appUser.Id,
                Symbol = request.Symbol,
                Quantity = request.Quantity,
                Price = stock.Price,
                TotalAmount = totalAmount,
                IsPurchase = true,
                Date = DateTime.UtcNow
            };

            await _transactionRepo.CreateAsync(transaction);
            await _userManager.UpdateAsync(appUser);
            await _stockRepo.UpdateAsync(stock.Id, new UpdateStockRequestDto
            {
                Symbol = stock.Symbol,
                Name = stock.Name,
                Quantity = stock.Quantity,
                Price = stock.Price
            });

            return Ok();
        }

        [HttpPost("sell")]
        [Authorize]
        public async Task<IActionResult> Sell([FromBody] SellDto request)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var stock = await _stockRepo.GetBySymbolAsync(request.Symbol);
            if (stock == null) return BadRequest("Stock not found");

            decimal totalIncome = request.Quantity * stock.Price;
            decimal commission = totalIncome * _commissionRate;
            decimal totalAmount = totalIncome - commission;

            appUser.Balance += totalAmount;
            stock.Quantity += request.Quantity;

            var transaction = new Transaction
            {
                UserId = appUser.Id,
                Symbol = request.Symbol,
                Quantity = request.Quantity,
                Price = stock.Price,
                TotalAmount = totalAmount,
                IsPurchase = false,
                Date = DateTime.UtcNow
            };

            await _transactionRepo.CreateAsync(transaction);
            await _userManager.UpdateAsync(appUser);
            await _stockRepo.UpdateAsync(stock.Id, new UpdateStockRequestDto
            {
                Symbol = stock.Symbol,
                Name = stock.Name,
                Quantity = stock.Quantity,
                Price = stock.Price
            });

            return Ok();
        }
    }    
}


