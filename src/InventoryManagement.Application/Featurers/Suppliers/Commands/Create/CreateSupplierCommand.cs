using InventoryManagement.Application.Dto.Suppliers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Commands.Create
{
    public class CreateSupplierCommand : IRequest<Unit>
    {
        public CreateSupplierDto? SupplierDto { get; set; }
    }
}
