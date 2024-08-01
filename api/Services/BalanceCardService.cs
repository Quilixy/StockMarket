using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BalanceCard;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class BalanceCardService : IBalanceCardService
    {
        private readonly IBalanceCardRepository _balanceCardRepository;
        private readonly IBalanceRepository _balanceRepository;

        public BalanceCardService(IBalanceCardRepository balanceCardRepository, IBalanceRepository balanceRepository)
        {
            _balanceCardRepository = balanceCardRepository;
            _balanceRepository = balanceRepository;
        }

        public async Task CreateBalanceCard(CreateBalanceCardDto createBalanceCardDto)
        {
            var balanceCard = new BalanceCard
            {
                Code = createBalanceCardDto.Code,
                Amount = createBalanceCardDto.Amount,
                IsUsed = false
            };

            await _balanceCardRepository.CreateBalanceCard(balanceCard);
        }

        public async Task UseBalanceCard(string code, string username)
        {
            var balanceCard = await _balanceCardRepository.GetBalanceCardByCode(code);

            if (balanceCard == null || balanceCard.IsUsed)
            {
                throw new System.Exception("Balance card is invalid or already used.");
            }

            var user = await _balanceRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new System.Exception("Username is not found.");
            }

            user.Balance += balanceCard.Amount;
            balanceCard.IsUsed = true;

            await _balanceRepository.UpdateUserBalance(user);
            await _balanceCardRepository.UpdateBalanceCard(balanceCard);
        }
    }
}