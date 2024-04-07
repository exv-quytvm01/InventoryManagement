using AutoMapper;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Commands.Delete
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand,Unit>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.Get(request.Id);
            await _supplierRepository.Delete(supplier);
            return Unit.Value;
        }
    }
}
