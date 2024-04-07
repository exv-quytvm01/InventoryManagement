using InventoryManagement.Application.Dto.ProductionOrderDetails;
using InventoryManagement.Application.Dto.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.ProductOrders
{
    public class DetailProductOrderDto
    {
        public ProductionOrderDto ProductionOrder { get; set; }
        public List<ProductionOrderDetailDto> Details { get; set; }
    }
}
