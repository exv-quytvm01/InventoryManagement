using InventoryManagement.Application.Dto.ProductOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetProOrders
{
    public class GetProOrdersQuery : IRequest<List<ProductionOrderDto>>
    {
    }
}
