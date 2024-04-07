using InventoryManagement.Application.Dto.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.SaleOrders
{
    public class SaleOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto? Customer { get; set; }
        public DateTime Date { get; set; }
        public float? total_anmt { get; set; }
    }
}
