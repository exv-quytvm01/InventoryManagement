using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Dto.Categories;

namespace InventoryManagement.Application.Dto.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ProductCode { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public string? Image { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public float? PurchasePrice { get; set; }
        public float? MinimumPrice { get; set; }
        public float? RetailPrice { get; set; }
        public float? BlockPrice { get; set; }
    }
}
