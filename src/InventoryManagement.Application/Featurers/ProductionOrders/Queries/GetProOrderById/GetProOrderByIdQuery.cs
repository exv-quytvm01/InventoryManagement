using InventoryManagement.Application.Dto.ProductOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetProOrderById
{
    public class GetProOrderByIdQuery : IRequest<ProductionOrderDto>
    {
        public int Id { get; set; } 
    }
}
