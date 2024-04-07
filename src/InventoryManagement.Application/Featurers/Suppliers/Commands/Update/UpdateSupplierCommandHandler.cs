using AutoMapper;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Commands.Update
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand,Unit>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.Get(request.SupplierDto.Id);
            _mapper.Map(request.SupplierDto, supplier);
            await _supplierRepository.Update(supplier);
            return Unit.Value;
        }
    }
}
