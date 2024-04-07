using AutoMapper;
using InventoryManagement.Application.Dto.SaleOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrderDetails.Queries.GetById
{
    public class GetSaleOderDetailQueryHandler : IRequestHandler<GetSaleOderDetailQuery,SaleOrderDto>
    {
        private readonly ISaleOrderDetailRepository _saleOrderDetailRepository;
        private readonly IMapper _mapper;

        public GetSaleOderDetailQueryHandler(ISaleOrderDetailRepository saleOrderDetailRepository, IMapper mapper)
        {
            _saleOrderDetailRepository = saleOrderDetailRepository;
            _mapper = mapper;
        }

        public async Task<SaleOrderDto> Handle(GetSaleOderDetailQuery request, CancellationToken cancellationToken)
        {
            var item = await _saleOrderDetailRepository.GetSaleOrderDetails(request.Id);
            return _mapper.Map<SaleOrderDto>(item);
        }
    }
}
