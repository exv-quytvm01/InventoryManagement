using InventoryManagement.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Stocks.Queries.GetStocksByPage
{
    public class GetStocksQueryByPage : IRequest<PaginatedListDto<StockDto>>
    {
        public string? searchString { get; set; }
        public string sortOrder { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? currentFilter { get; set; }
    }
}
