using ExampleProject.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.Products
{
    public class CreateProductDto
    {
        public string? Title { get; set; }
        public string? ProductCode { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? Image { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public float? PurchasePrice { get; set; }
        public float? MinimumPrice { get; set; }
        public float? RetailPrice { get; set; }
        public float? BlockPrice { get; set; }
    }
}
