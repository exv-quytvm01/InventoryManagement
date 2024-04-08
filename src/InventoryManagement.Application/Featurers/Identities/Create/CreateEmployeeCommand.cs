using InventoryManagement.Application.Dto.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Create
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public ViewAddEmployee? viewadd { get; set; }
    }
}
