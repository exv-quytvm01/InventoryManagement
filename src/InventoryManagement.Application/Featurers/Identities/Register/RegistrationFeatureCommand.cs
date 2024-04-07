using InventoryManagement.Application.Dto.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Register
{
    public class RegistrationFeatureCommand : IRequest<RegistrationResponse>
    {
        public RegistrationRequest RegisRequest { get; set; }
    }
}
