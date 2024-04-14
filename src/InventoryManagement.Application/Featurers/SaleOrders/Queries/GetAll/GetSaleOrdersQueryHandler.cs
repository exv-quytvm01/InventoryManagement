using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.SaleOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Featurers.SaleOrders.Queries.GetAll
{
    public class GetSaleOrdersQueryHandler : IRequestHandler<GetSaleOrdersQuery, PaginatedListDto<SaleOrderDto>>
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly IMapper _mapper;

        public GetSaleOrdersQueryHandler(ISaleOrderRepository saleOrderRepository, IMapper mapper)
        {
            _saleOrderRepository = saleOrderRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<SaleOrderDto>> Handle(GetSaleOrdersQuery request, CancellationToken cancellationToken)
        {
            var sales = _saleOrderRepository.getListByCondition();

            if (!string.IsNullOrEmpty(request.searchString))
            {
                sales = sales.Include(s => s.Customer).Where(s => s.Customer.CustomerName.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {

                case "date_asc":
                    sales = sales.OrderBy(e => e.LastModified);
                    break;
                case "date_desc":
                    sales = sales.OrderByDescending(s => s.LastModified);
                    break;
            }
            List<SaleOrder> item1;
            if (!string.IsNullOrEmpty(request.searchString))
            {
                item1 = await sales.ToListAsync();
            }
            else
            {
                item1 = await sales.Include(s => s.Customer).ToListAsync();
            }
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _saleOrderRepository.CreateAsync(sales, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<SaleOrderDto>>(items);
            var pagined = new PaginatedListDto<SaleOrderDto>(itemsDto, item1.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
