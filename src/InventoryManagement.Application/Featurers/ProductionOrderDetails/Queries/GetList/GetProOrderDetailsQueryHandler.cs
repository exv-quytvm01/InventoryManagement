using AutoMapper;
using InventoryManagement.Application.Dto.ProductionOrderDetails;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrderDetails.Queries.GetList
{
    public class GetProOrderDetailsQueryHandler : 
        IRequestHandler<GetProOrderDetailsQuery,List<ProductionOrderDetailDto>>
    {
        private readonly IProductionOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public GetProOrderDetailsQueryHandler(IProductionOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductionOrderDetailDto>> Handle(GetProOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetListProOrderDetails();
            return _mapper.Map<List<ProductionOrderDetailDto>>(items);
        }
    }
}
