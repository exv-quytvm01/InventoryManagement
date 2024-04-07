using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.ProductOrders
{
    public class ProductionOrderDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public SupplierDto? Supplier { get; set; }
        public DateTime Date { get; set; }
        public float? total_anmt { get; set; }
    }
}
