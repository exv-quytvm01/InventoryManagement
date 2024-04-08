using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.Identity
{
    public class ViewAddEmployee
    {
        public CreateEmployeeDto EmployeeDto { get; set; }
        public IFormFile Image { get; set; }
    }
}
