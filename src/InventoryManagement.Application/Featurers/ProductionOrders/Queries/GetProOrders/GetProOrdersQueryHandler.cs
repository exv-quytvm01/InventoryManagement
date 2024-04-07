using AutoMapper;
using InventoryManagement.Application.Dto.ProductOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetProOrders
{
    public class GetProOrdersQueryHandler : IRequestHandler<GetProOrdersQuery,List<ProductionOrderDto>>
    {
        private readonly IProductionOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetProOrdersQueryHandler(IProductionOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductionOrderDto>> Handle(GetProOrdersQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetListProductionOrders();
            return _mapper.Map<List<ProductionOrderDto>>(items);
        }
    }
}
