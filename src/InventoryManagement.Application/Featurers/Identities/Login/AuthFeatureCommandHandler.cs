using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Login
{
    public class AuthFeatureCommandHandler : IRequestHandler<AuthFeatureCommand, AuthResponse>
    {
        private readonly IAcountRepository _acountRepository;

        public AuthFeatureCommandHandler(IAcountRepository acountRepository)
        {
            _acountRepository = acountRepository;
        }

        public async Task<AuthResponse> Handle(AuthFeatureCommand request, CancellationToken cancellationToken)
        {
            var response = await _acountRepository.Login(request.AuthRequest);
            return response;
        }
    }
}
