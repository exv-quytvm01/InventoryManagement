using AutoMapper;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.IRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, PaginatedListDto<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            //if (request.searchString != null)
            //{
            //    request.pageNumber = 1;
            //}
            //else
            //{
            //    request.searchString = request.currentFilter;
            //}

            var categories = _categoryRepository.getListByCondition();
            var count = categories.Count();
            if (!string.IsNullOrEmpty(request.searchString))
            {
                categories = categories.Where(s => s.CategoryName.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(e => e.CategoryName);
                    break;
                case "date_asc":
                    categories = categories.OrderBy(e => e.LastModified);
                    break;
                case "date_desc":
                    categories = categories.OrderByDescending(s => s.LastModified);
                    break;
            }
            var item1 = await categories.ToListAsync();
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _categoryRepository.CreateAsync(categories, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<CategoryDto>>(items);
            var pagined = new PaginatedListDto<CategoryDto>(itemsDto,item1.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
