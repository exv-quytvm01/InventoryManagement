using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.ProductOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetProOrders
{
    public class GetProOrdersQuery : IRequest<PaginatedListDto<ProductionOrderDto>>
    {
        public string? searchString { get; set; }
        public string sortOrder { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? currentFilter { get; set; }
    }
}
