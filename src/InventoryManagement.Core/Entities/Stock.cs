
using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Core.Entities
{
    public class Stock : BaseEntity
    {
        public int Id { get; set; }
        [AllowNull]
        public DateTime DateCreated { get; set; }
        [AllowNull]
        public DateTime LastModified { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int StockQuantity { get; set; }
        public string? Unit {  get; set; }
    }
}
