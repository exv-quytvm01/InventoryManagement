using InventoryManagement.Application.Dto.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Create
{
    public class CreateUserCommand : IRequest<bool>
    {
        public CreateEmployeeDto employee { get; set; }
        public IFormFile Image { get; set; }
    }
}
