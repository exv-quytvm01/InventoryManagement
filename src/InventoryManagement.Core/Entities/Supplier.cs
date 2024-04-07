
using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Core.Entities
{
    public class Supplier : BaseEntity
    {
        public int Id { get; set; }
        [AllowNull]
        public DateTime DateCreated { get; set; }
        [AllowNull]
        public DateTime LastModified { get; set; }
        public string? SupplierCode { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierPhone { get; set; }
        public string? SupplierEmail { get; set; }
        public string? SupplierAddress { get; set; }
    }
}
