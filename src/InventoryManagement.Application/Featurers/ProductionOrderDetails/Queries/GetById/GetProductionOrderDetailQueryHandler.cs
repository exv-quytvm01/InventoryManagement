using AutoMapper;
using InventoryManagement.Application.Dto.ProductionOrderDetails;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrderDetails.Queries.GetById
{
    public class GetProductionOrderDetailQueryHandler :
        IRequestHandler<GetProductionOrderDetailQuery, ProductionOrderDetailDto>
    {
        private readonly IProductionOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public GetProductionOrderDetailQueryHandler(IProductionOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductionOrderDetailDto> Handle(GetProductionOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetProOrderDetails(request.Id);
            return _mapper.Map<ProductionOrderDetailDto>(item);
        }
    }
}
