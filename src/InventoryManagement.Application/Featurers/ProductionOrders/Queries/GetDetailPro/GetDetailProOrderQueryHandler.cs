using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.ProductionOrderDetails;
using InventoryManagement.Application.Dto.ProductOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetDetailPro
{
    public class GetDetailProOrderQueryHandler : IRequestHandler<GetDetailProOrderQuery, DetailProductOrderDto>
    {
        private readonly IProductionOrderRepository _repository;
        private readonly IProductionOrderDetailRepository _detailRepository;
        private readonly IMapper _mapper;

        public GetDetailProOrderQueryHandler(
            IProductionOrderRepository repository, 
            IProductionOrderDetailRepository detailRepository, 
            IMapper mapper)
        {
            _repository = repository;
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<DetailProductOrderDto> Handle(GetDetailProOrderQuery request, CancellationToken cancellationToken)
        {
            var po = await _repository.GetProductionOrderDetails(request.Id);
            var items = await _detailRepository.GetProOrderDetailsByProOrder(request.Id);
            var pod = new DetailProductOrderDto()
            {
                ProductionOrder = _mapper.Map<ProductionOrderDto>(po),
                Details = _mapper.Map<List<ProductionOrderDetailDto>>(items)
            };
            return pod;
        }
    }
}
