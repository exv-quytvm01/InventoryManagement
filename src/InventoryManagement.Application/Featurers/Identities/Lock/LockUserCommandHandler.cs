using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Lock
{
    public class LockUserCommandHandler : IRequestHandler<LockUserCommand,bool>
    {
        private readonly IAcountRepository _acountRepository;

        public LockUserCommandHandler(IAcountRepository acountRepository)
        {
            _acountRepository = acountRepository;
        }

        public async Task<bool> Handle(LockUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _acountRepository.LockUser(request.Id);
            return response;
        }
    }
}
