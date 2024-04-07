using AutoMapper;
using InventoryManagement.Application.Dto.SaleOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrders.Queries.GetAll
{
    public class GetSaleOrdersQueryHandler : IRequestHandler<GetSaleOrdersQuery,List<SaleOrderDto>>
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly IMapper _mapper;

        public GetSaleOrdersQueryHandler(ISaleOrderRepository saleOrderRepository, IMapper mapper)
        {
            _saleOrderRepository = saleOrderRepository;
            _mapper = mapper;
        }

        public async Task<List<SaleOrderDto>> Handle(GetSaleOrdersQuery request, CancellationToken cancellationToken)
        {
            var item = await _saleOrderRepository.GetListSaleOrders();
            return _mapper.Map<List<SaleOrderDto>>(item);   
        }
    }
}
