using AutoMapper;
using InventoryManagement.Application.Dto.SaleOrderDetails;
using InventoryManagement.Application.Dto.SaleOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrders.Queries.GetDetailSaleOrder
{
    public class GetDetailSaleOrderQueryHandler : IRequestHandler<GetDetailSaleOrderQuery, DetailSaleOrderDto>
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly ISaleOrderDetailRepository _detailRepository;
        private readonly IMapper _mapper;

        public GetDetailSaleOrderQueryHandler(
            ISaleOrderRepository saleOrderRepository,
            ISaleOrderDetailRepository detailRepository, 
            IMapper mapper)
        {
            _saleOrderRepository = saleOrderRepository;
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<DetailSaleOrderDto> Handle(GetDetailSaleOrderQuery request, CancellationToken cancellationToken)
        {
            var so = await _saleOrderRepository.Get(request.Id);
            var items = await  _detailRepository.GetSaleOrderDetailsBySaleOrder(request.Id);
            var sod = new DetailSaleOrderDto() {
                SaleOrderDto = _mapper.Map<SaleOrderDto>(so),
                Details = _mapper.Map<List<SaleOrderDetailDto>>(items)
            };
            return sod;
        }
    }
}
