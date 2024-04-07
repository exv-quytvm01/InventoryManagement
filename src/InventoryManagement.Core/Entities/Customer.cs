
using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Core.Entities
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        [AllowNull]
        public DateTime DateCreated { get; set; }
        [AllowNull]
        public DateTime LastModified { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set;}
        public string? CustomerEmail { get; set;}
        public string? Location { get; set;}
        public string? business { get; set;}
    }
}
