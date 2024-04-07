
using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Core.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        [AllowNull]
        public DateTime DateCreated { get; set; }
        [AllowNull]
        public DateTime LastModified { get; set; }
        public string? Title { get; set; }
        public string? ProductCode { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [AllowNull]
        public string? Image { get; set;}
        public string? Brand { get; set;}
        public string? Description { get; set; }
        public float? PurchasePrice { get; set; }
        public float? MinimumPrice { get; set; }
        public float? RetailPrice { get; set; }
        public float? BlockPrice { get;set; }
    }
}
