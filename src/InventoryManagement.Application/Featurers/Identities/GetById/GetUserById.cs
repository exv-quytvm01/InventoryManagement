using InventoryManagement.Application.Dto.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.GetById
{
    public class GetUserById : IRequest<CreateEmployeeDto>
    {
        public string Id { get; set; }
    }
}
