using AutoMapper;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.Dto.Suppliers;
using InventoryManagement.Application.IRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Queries.GetSuppliersByPage
{
    public class GetSuppliersQueryByPageHandler : IRequestHandler<GetSuppliersQueryByPage,PaginatedListDto<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSuppliersQueryByPageHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<SupplierDto>> Handle(GetSuppliersQueryByPage request, CancellationToken cancellationToken)
        {
            var supliers = _supplierRepository.getListByCondition();
            var count = supliers.Count();
            if (!string.IsNullOrEmpty(request.searchString))
            {
                supliers = supliers.Where(s => s.SupplierName.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {
                case "name_desc":
                    supliers = supliers.OrderByDescending(e => e.SupplierName);
                    break;
                case "date_asc":
                    supliers = supliers.OrderBy(e => e.LastModified);
                    break;
                case "date_desc":
                    supliers = supliers.OrderByDescending(s => s.LastModified);
                    break;
            }
            var item1 = await supliers.ToListAsync();
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _supplierRepository.CreateAsync(supliers, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<SupplierDto>>(items);
            var pagined = new PaginatedListDto<SupplierDto>(itemsDto, item1.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
