using InventoryManagement.Application.Dto.ProductOrders;
using InventoryManagement.Application.Dto.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.SaleOrderDetails
{
    public class CreateSaleOrderDetailDto
    {
        public int SaleOrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public float OrderPrice { get; set; }
        public string? Unit { get; set; }
    }
}
