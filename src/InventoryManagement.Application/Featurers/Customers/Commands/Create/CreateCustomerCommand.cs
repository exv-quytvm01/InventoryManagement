using InventoryManagement.Application.Dto.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Customers.Commands.Create
{
    public class CreateCustomerCommand : IRequest<Unit>
    {
        public CreateCustomerDto? CustomerDto { get; set; }
    }
}
