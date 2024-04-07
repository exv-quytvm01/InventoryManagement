using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Lock
{
    public class UnLockCommandHandler : IRequestHandler<UnLockCommand,bool>
    {
        private readonly IAcountRepository _acountRepository;

        public UnLockCommandHandler(IAcountRepository acountRepository)
        {
            _acountRepository = acountRepository;
        }

        public async Task<bool> Handle(UnLockCommand request, CancellationToken cancellationToken)
        {
            var response = await _acountRepository.UnlockUser(request.Id);
            return response;
        }
    }
}
