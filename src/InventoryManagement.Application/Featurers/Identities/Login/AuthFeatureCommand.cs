using InventoryManagement.Application.Dto.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Login
{
    public class AuthFeatureCommand : IRequest<AuthResponse>
    {
        public AuthRequest AuthRequest { get; set; }
    }
}
