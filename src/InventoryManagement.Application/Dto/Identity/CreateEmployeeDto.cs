using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.Identity
{
    public class CreateEmployeeDto
    {
        public string Id { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string? CCCD { get; set; }
        public string? Image { get; set; }
        public string RoleId { get; set; }
        public string? Position { get; set; }
        public string Password { get; set; }
        //public bool IsLockedOut { get; set; }
    }
}
