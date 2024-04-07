using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.GetRoles
{
    public class GetRoles : IRequest<List<IdentityRole>>
    {
    }
}
