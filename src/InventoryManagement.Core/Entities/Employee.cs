using InventoryManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace ExampleProject.Core.Entities
{
    public class Employee : IdentityUser,BaseEntity
    {
        [AllowNull]
        public DateTime DateCreated { get; set; }
        [AllowNull]
        public DateTime LastModified { get; set; }
        [AllowNull]
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        [AllowNull]
        public string? CCCD { get; set;}
        [AllowNull]
        public string? Image { get; set; }
        [AllowNull]
        public string? Position { get; set; }
    }
}
