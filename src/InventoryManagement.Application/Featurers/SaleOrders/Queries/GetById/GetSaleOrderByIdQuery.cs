using InventoryManagement.Application.Dto.SaleOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrders.Queries.GetById
{
    public class GetSaleOrderByIdQuery : IRequest<SaleOrderDto>
    {
        public int Id { get; set; }
    }
}
