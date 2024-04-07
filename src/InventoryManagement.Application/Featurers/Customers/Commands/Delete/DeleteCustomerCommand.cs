using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
