using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.Dto.ProductOrders;
using InventoryManagement.Application.IRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetProOrders
{
    public class GetProOrdersQueryHandler : IRequestHandler<GetProOrdersQuery, PaginatedListDto<ProductionOrderDto>>
    {
        private readonly IProductionOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetProOrdersQueryHandler(IProductionOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<ProductionOrderDto>> Handle(GetProOrdersQuery request, CancellationToken cancellationToken)
        {
            var purchase = _repository.getListByCondition();
            
            if (!string.IsNullOrEmpty(request.searchString))
            {
                purchase = purchase.Include(s => s.Supplier).Where(s => s.Supplier.SupplierName.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {
                
                case "date_asc":
                    purchase = purchase.OrderBy(e => e.LastModified);
                    break;
                case "date_desc":
                    purchase = purchase.OrderByDescending(s => s.LastModified);
                    break;
            }
            List<ProductionOrder> item1;
            if (!string.IsNullOrEmpty(request.searchString))
            {
                item1 = await purchase.ToListAsync();
            }
            else
            {
                item1 = await purchase.Include(s => s.Supplier).ToListAsync();
            }
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _repository.CreateAsync(purchase, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<ProductionOrderDto>>(items);
            var pagined = new PaginatedListDto<ProductionOrderDto>(itemsDto, item1.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
