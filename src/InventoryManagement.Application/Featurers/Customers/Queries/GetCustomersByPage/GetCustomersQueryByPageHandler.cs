using AutoMapper;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.Dto.Customers;
using InventoryManagement.Application.IRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Customers.Queries.GetCustomersByPage
{
    public class GetCustomersQueryByPageHandler : IRequestHandler<GetCustomersQueryByPage,PaginatedListDto<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersQueryByPageHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<CustomerDto>> Handle(GetCustomersQueryByPage request, CancellationToken cancellationToken)
        {
            var customers = _customerRepository.getListByCondition();
            //
            if (!string.IsNullOrEmpty(request.searchString))
            {
                customers = customers.Where(s => s.CustomerName.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(e => e.CustomerName);
                    break;
                case "date_asc":
                    customers = customers.OrderBy(e => e.LastModified);
                    break;
                case "date_desc":
                    customers = customers.OrderByDescending(s => s.LastModified);
                    break;
            }
            var item1 = await customers.ToListAsync();
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _customerRepository.CreateAsync(customers, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<CustomerDto>>(items);
            var pagined = new PaginatedListDto<CustomerDto>(itemsDto, item1.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
