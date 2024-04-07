using InventoryManagement.Application.Dto.SaleOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrders.Queries.GetDetailSaleOrder
{
    public class GetDetailSaleOrderQuery : IRequest<DetailSaleOrderDto>
    {
        public int Id { get; set; }
    }
}
