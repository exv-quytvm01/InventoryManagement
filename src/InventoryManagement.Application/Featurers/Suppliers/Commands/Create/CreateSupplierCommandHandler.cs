using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Commands.Create
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand,Unit>
    {
        private readonly ISupplierRepository _supplierRepository; 
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplier>(request.SupplierDto);
            supplier = await _supplierRepository.Add(supplier);
            return Unit.Value;
        }
    }
}
