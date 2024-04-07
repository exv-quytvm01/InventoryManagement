using InventoryManagement.Application.Dto.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Dto.SaleOrders;

namespace InventoryManagement.Application.Dto.SaleOrderDetails
{
    public class SaleOrderDetailDto
    {
        public int Id { get; set; }
        public int SaleOrderId { get; set; }
        public SaleOrderDto? SaleOrder { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int OrderQuantity { get; set; }
        public float OrderPrice { get; set; }
        public string? Unit { get; set; }
    }
}
