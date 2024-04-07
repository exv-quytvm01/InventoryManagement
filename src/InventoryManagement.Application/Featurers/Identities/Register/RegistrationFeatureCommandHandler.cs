using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Register
{
    public class RegistrationFeatureCommandHandler : IRequestHandler<RegistrationFeatureCommand, RegistrationResponse>
    {
        private readonly IAcountRepository _countRepository;

        public RegistrationFeatureCommandHandler(IAcountRepository countRepository)
        {
            _countRepository = countRepository;
        }

        public async Task<RegistrationResponse> Handle(RegistrationFeatureCommand request, CancellationToken cancellationToken)
        {
            var response = await _countRepository.Register(request.RegisRequest);
            return response;
        }
    }
}
