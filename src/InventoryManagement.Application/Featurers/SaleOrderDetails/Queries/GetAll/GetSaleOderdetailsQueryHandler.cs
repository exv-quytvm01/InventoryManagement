using AutoMapper;
using InventoryManagement.Application.Dto.SaleOrderDetails;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrderDetails.Queries.GetAll
{
    public class GetSaleOderdetailsQueryHandler : IRequestHandler<GetSaleOderdetailsQuery,List<SaleOrderDetailDto>>
    {
        private readonly ISaleOrderDetailRepository _saleOrderDetailRepository;
        private readonly IMapper _mapper;

        public GetSaleOderdetailsQueryHandler(ISaleOrderDetailRepository saleOrderDetailRepository, IMapper mapper)
        {
            _saleOrderDetailRepository = saleOrderDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<SaleOrderDetailDto>> Handle(GetSaleOderdetailsQuery request, CancellationToken cancellationToken)
        {
            var items = await _saleOrderDetailRepository.GetListSaleOrderDetails();
            return _mapper.Map<List<SaleOrderDetailDto>>(items);    
        }
    }
}
