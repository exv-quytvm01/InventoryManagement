using InventoryManagement.Application.Dto.Suppliers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Commands.Update
{
    public class UpdateSupplierCommand : IRequest<Unit>
    {
        public SupplierDto? SupplierDto { get; set; }
    }
}
