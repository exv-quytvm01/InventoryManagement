using AutoMapper;
using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.Dto.Products;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Categories.Queries.GetCategoys
{
    public class GetCategorysQueryHandler : IRequestHandler<GetCategorysQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategorysQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategorysQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
