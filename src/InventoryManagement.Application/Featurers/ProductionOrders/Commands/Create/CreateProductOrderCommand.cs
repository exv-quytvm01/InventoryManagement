using InventoryManagement.Application.Dto.ProductOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Commands.Create
{
    public class CreateProductOrderCommand : IRequest<Unit>
    {
        public CreateProductOrderDto? ProductOrderDto { get; set; }
    }
}
