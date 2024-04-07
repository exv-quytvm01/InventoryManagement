using InventoryManagement.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Stocks.Queries.GetStocks
{
    public class GetStocksQuery : IRequest<List<StockDto>>
    {
    }
}
