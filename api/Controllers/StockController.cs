using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        private readonly IStockPriceHistoryRepository _priceHistoryRepo;
        public StockController(ApplicationDBContext context, 
        IStockRepository stockRepo,
        IStockPriceHistoryRepository priceHistoryRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
            _priceHistoryRepo = priceHistoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()    
        {
            var stocks = await _stockRepo.GetAllAsync();

             var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (stockDto.Quantity == 0)
            {
                stockDto.Quantity = 10000;
            }
            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
            //var stockModel = await _stockRepo.GetBySymbolAsync(updateDto.Symbol);
            if (stockModel == null)
            {
                return NotFound();
            }
            
            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepo.DeleteAsync(id);

            if(stockModel==null)
            {
                return NotFound();
            }
            
            
            return NoContent();
        }

        [HttpPut("{id}/halt")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> HaltTrading(int id, [FromBody] bool halt)
        {
            await _stockRepo.HaltTradingAsync(id, halt);
            return NoContent();
        }

        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetPriceHistory(int id)
        {
            var history = await _priceHistoryRepo.GetByStockIdAsync(id);
            return Ok(history);
        }
        
    }
}