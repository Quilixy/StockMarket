using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Portfolio;
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
        private readonly IPortfolioRepository _portfolioRepo;
        private readonly IBalanceService _balanceService;
        private readonly decimal _commissionRate = 0.05m; // %5 komisyon

        public TransactionController(UserManager<AppUser> userManager,
        IStockRepository stockRepo,
        ITransactionRepository transactionRepo,
        IPortfolioRepository portfolioRepo,
        IBalanceService balanceService)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _transactionRepo = transactionRepo;
            _portfolioRepo = portfolioRepo;
            _balanceService = balanceService;
        }

        [HttpPost("purchase")]
        [Authorize]
        public async Task<IActionResult> Purchase([FromBody] PurchaseDto request)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var systemBalance = await _balanceService.GetSystemBalance();

            var stock = await _stockRepo.GetBySymbolAsync(request.Symbol);
            if (stock == null) return BadRequest("Stock not found");

            

            decimal totalCost = request.Quantity * stock.Price;
            decimal commission = totalCost * _commissionRate;
            decimal totalAmount = totalCost + commission;

            if (appUser.Balance < totalAmount)
                return BadRequest("Insufficient balance");

            appUser.Balance -= totalAmount;
            stock.Quantity -= request.Quantity;
            if (systemBalance == null)
            {
                systemBalance = new SystemBalance { Balance = commission };
            }
            else
            {
                systemBalance.Balance += commission;
                await _balanceService.UpdateSystemBalance(systemBalance.Balance);
            }
            
            

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

            var portfolio = await _portfolioRepo.GetByUserAndSymbolAsync(appUser.Id, request.Symbol);
            if (portfolio == null)
            {
                portfolio = new Portfolio
                {
                    AppUserId = appUser.Id,
                    StockId = stock.Id,
                    Quantity = request.Quantity
                };
                await _portfolioRepo.CreateAsync(portfolio);
            }
            else
            {
                portfolio.Quantity += request.Quantity;
                await _portfolioRepo.UpdateAsync(portfolio, new UpdatePortfolioRequestDto
                {
                    Symbol = portfolio.Stock.Symbol,
                    Quantity = portfolio.Quantity
                });
            }

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
            var systemBalance = await _balanceService.GetSystemBalance();

            var stock = await _stockRepo.GetBySymbolAsync(request.Symbol);
            if (stock == null) return BadRequest("Stock not found");

            decimal totalIncome = request.Quantity * stock.Price;
            decimal commission = totalIncome * _commissionRate;
            decimal totalAmount = totalIncome - commission;

            var portfolio = await _portfolioRepo.GetByUserAndSymbolAsync(appUser.Id, request.Symbol);
            if (portfolio == null || portfolio.Quantity < request.Quantity)
                return BadRequest("Insufficient stock in portfolio");

            appUser.Balance += totalAmount;
            stock.Quantity += request.Quantity;
            if (systemBalance == null)
            {
                systemBalance = new SystemBalance { Balance = commission };
            }
            else
            {
                systemBalance.Balance += commission;
                await _balanceService.UpdateSystemBalance(systemBalance.Balance);
            }

            portfolio.Quantity -= request.Quantity;
            if (portfolio.Quantity == 0)
            {
                await _portfolioRepo.DeletePortfolio(appUser, request.Symbol);
            }
            else
            {
                await _portfolioRepo.UpdateAsync(portfolio, new UpdatePortfolioRequestDto
                {
                    Symbol = portfolio.Stock.Symbol,
                    Quantity = portfolio.Quantity
                });
            }

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
        [HttpGet("history")]
        [Authorize]
        public async Task<IActionResult> GetTransactionHistory()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var transactions = await _transactionRepo.GetByUserIdAsync(appUser.Id);

            if (transactions == null || !transactions.Any())
            {
                return NotFound("No transactions found for the user.");
            }

            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                Symbol = t.Symbol,
                Quantity = t.Quantity,
                Price = t.Price,
                TotalAmount = t.TotalAmount,
                IsPurchase = t.IsPurchase,
                Date = t.Date
            }).ToList();

            return Ok(transactionDtos);
        }
    }    
}


