using ExampleProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Config
{
    public class UserConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                 new Employee
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@gmail.com",
                     NormalizedEmail = "ADMIN@GMAIL.COM",
                     EmployeeName = "System Admin",
                     UserName = "Admin01",
                     NormalizedUserName = "ADMIN01COM",
                     PasswordHash = hasher.HashPassword(null, "Ps@12345678"),
                     EmailConfirmed = true
                 },
                 new Employee
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@gmail.com",
                     NormalizedEmail = "USER@GMAIL.COM",
                     EmployeeName = "System User",
                     UserName = "User01",
                     NormalizedUserName = "USER01COM",
                     PasswordHash = hasher.HashPassword(null, "Ps@12345678"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}
