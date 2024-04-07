using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Dto.Products;

namespace InventoryManagement.Application.Featurers.Products.Queries.GetProductsByPage
{
    public class GetProductsQueryByPage : IRequest<PaginatedListDto<ProductDto>>
    {
        public string searchString { get; set; }
        public string sortOrder { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string currentFilter { get; set; }
    }
}
