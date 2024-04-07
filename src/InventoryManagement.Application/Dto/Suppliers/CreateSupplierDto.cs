using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.Suppliers
{
    public class CreateSupplierDto
    {
        public string? SupplierCode { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierPhone { get; set; }
        public string? SupplierEmail { get; set; }
        public string? SupplierAddress { get; set; }
    }
}
