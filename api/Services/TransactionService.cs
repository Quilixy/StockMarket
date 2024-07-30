using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
public class TransactionService
{
    private readonly ApplicationDBContext _context;
    private readonly decimal _commissionRate = 0.05m; // %5 komisyon

    public TransactionService(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<bool> PurchaseStockAsync(string userId, string symbol, int quantity)
    {
        var stock = await _context.Stocks.SingleOrDefaultAsync(s => s.Symbol == symbol);
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (stock == null || user == null || stock.Quantity < quantity)
            return false;

        decimal totalCost = quantity * stock.Price;
        decimal commission = totalCost * _commissionRate;
        decimal totalAmount = totalCost + commission;

        if (user.Balance < totalAmount)
            return false;

        // İşlemi gerçekleştir
        user.Balance -= totalAmount;
        stock.Quantity -= quantity;

        var transaction = new Transaction
        {
            UserId = userId,
            Symbol = symbol,
            Quantity = quantity,
            Price = stock.Price,
            TotalAmount = totalAmount,
            IsPurchase = true,
            Date = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SellStockAsync(string userId, string symbol, int quantity)
    {
        var stock = await _context.Stocks.SingleOrDefaultAsync(s => s.Symbol == symbol);
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (stock == null || user == null)
            return false;

        decimal totalIncome = quantity * stock.Price;
        decimal commission = totalIncome * _commissionRate;
        decimal totalAmount = totalIncome - commission;

        // İşlemi gerçekleştir
        user.Balance += totalAmount;
        stock.Quantity += quantity;

        var transaction = new Transaction
        {
            UserId = userId,
            Symbol = symbol,
            Quantity = quantity,
            Price = stock.Price,
            TotalAmount = totalAmount,
            IsPurchase = false,
            Date = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return true;
    }
}



}