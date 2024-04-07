using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.Suppliers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Queries.GetSuppliersByPage
{
    public class GetSuppliersQueryByPage : IRequest<PaginatedListDto<SupplierDto>>
    {
        public string? searchString { get; set; }
        public string sortOrder { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? currentFilter { get; set; }
    }
}
