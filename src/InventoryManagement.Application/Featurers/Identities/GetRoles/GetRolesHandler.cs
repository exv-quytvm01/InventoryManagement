using InventoryManagement.Application.IRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.GetRoles
{
    public class GetRolesHandler : IRequestHandler<GetRoles,List<IdentityRole>>
    {
        private readonly IAcountRepository _repository;

        public GetRolesHandler(IAcountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<IdentityRole>> Handle(GetRoles request, CancellationToken cancellationToken)
        {
            var roles = await _repository.ListRoles();
            return roles;
        }
    }
}
