using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto
{
    public class StockDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int StockQuantity { get; set; }
        public string? Unit { get; set; }
    }
}
