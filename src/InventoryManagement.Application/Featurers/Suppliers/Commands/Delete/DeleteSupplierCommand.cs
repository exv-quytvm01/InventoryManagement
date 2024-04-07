using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Commands.Delete
{
    public class DeleteSupplierCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
