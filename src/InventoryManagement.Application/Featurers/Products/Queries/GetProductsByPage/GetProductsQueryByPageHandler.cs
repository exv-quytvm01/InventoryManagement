using InventoryManagement.Application.Dto.Products;
using InventoryManagement.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagement.Application.IRepository;
using Microsoft.EntityFrameworkCore;
using ExampleProject.Core.Entities;

namespace InventoryManagement.Application.Featurers.Products.Queries.GetProductsByPage
{
    internal class GetProductsQueryByPageHandler : IRequestHandler<GetProductsQueryByPage, PaginatedListDto<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryByPageHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<ProductDto>> Handle(GetProductsQueryByPage request, CancellationToken cancellationToken)
        {
            //if (request.searchString != null)
            //{
            //    request.pageNumber = 1;
            //}
            //else
            //{
            //    request.searchString = request.currentFilter;
            //}

            var products = _productRepository.getListByCondition();
            if (!string.IsNullOrEmpty(request.searchString))
            {
                products = products.Include(s=>s.Category).Where(s => s.Title.Contains(request.searchString) || s.Description.Contains(request.searchString)
                || s.Brand.Contains(request.searchString) || s.Description.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(e => e.Title);
                    break;

                case "date_asc":
                    products = products.OrderBy(e => e.DateCreated);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.DateCreated);
                    break;
            }
            List<Product> item1;
            if (!string.IsNullOrEmpty(request.searchString))
            {
                item1 = await products.ToListAsync();
            }
            else
            {
                item1 = await products.Include(s => s.Category).ToListAsync();
            }
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _productRepository.CreateAsync(products, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<ProductDto>>(items);
            var pagined = new PaginatedListDto<ProductDto>(itemsDto, item1.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
