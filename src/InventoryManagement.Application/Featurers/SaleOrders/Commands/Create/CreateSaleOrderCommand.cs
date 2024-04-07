using InventoryManagement.Application.Dto.SaleOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrders.Commands.Create
{
    public class CreateSaleOrderCommand : IRequest<Unit>
    {
        public CreateSaleOrderDto? SaleOrderDto { get; set; }
    }
}
