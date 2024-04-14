using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.ProductionOrderDetails
{
    public class CreateProductionOrderDetailDto
    {
        public int Id { get; set; }
        public int ProductionOrderId { get; set; }
        public int ProductId { get; set; } 
        public int OrderQuantity { get; set; }
        public float Price { get; set; }
        public float OrderDiscount { get; set; }
        public string? Unit { get; set; }
    }
}
