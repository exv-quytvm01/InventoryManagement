using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Lock
{
    public class LockUserCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
