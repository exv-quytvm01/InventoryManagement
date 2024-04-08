using InventoryManagement.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Stocks.Command.Create
{
    public class CreateStockCommand : IRequest<StockDto>
    {
        public StockDto? Stock { get; set; }
    }
}
