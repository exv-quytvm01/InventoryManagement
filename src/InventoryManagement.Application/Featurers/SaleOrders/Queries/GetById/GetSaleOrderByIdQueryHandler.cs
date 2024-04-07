using AutoMapper;
using InventoryManagement.Application.Dto.SaleOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrders.Queries.GetById
{
    public class GetSaleOrderByIdQueryHandler : IRequestHandler<GetSaleOrderByIdQuery,SaleOrderDto>
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly IMapper _mapper;

        public GetSaleOrderByIdQueryHandler(ISaleOrderRepository saleOrderRepository, IMapper mapper)
        {
            _saleOrderRepository = saleOrderRepository;
            _mapper = mapper;
        }

        public async Task<SaleOrderDto> Handle(GetSaleOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _saleOrderRepository.GetSaleOrderDetail(request.Id);
            return _mapper.Map<SaleOrderDto>(item);
        }
    }
}
