using AutoMapper;
using InventoryManagement.Application.Dto.ProductOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetProOrderById
{
    public class GetProOrderByIdQueryHandler : IRequestHandler<GetProOrderByIdQuery, ProductionOrderDto>
    {
        private readonly IProductionOrderRepository _repository;
        private readonly IMapper mapper;

        public GetProOrderByIdQueryHandler(IProductionOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductionOrderDto> Handle(GetProOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetProductionOrderDetails(request.Id);
            return mapper.Map<ProductionOrderDto>(item);
        }
    }
}
