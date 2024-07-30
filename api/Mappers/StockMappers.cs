using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                Name = stockModel.Name,
                Quantity = stockModel.Quantity,
                Price = stockModel.Price
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol= stockDto.Symbol,
                Name = stockDto.Name,
                Quantity = stockDto.Quantity,
                Price = stockDto.Price
            };
        }
    }
}