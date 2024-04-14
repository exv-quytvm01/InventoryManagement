using InventoryManagement.Application.Dto.Customers;
using InventoryManagement.Application.Dto.SaleOrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.SaleOrders
{
    public class CreateSaleOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public float? total_anmt { get; set; }
        public List<CreateSaleOrderDetailDto> 
            ListSaleProducts { get; set; } = new List<CreateSaleOrderDetailDto>();
    }
}
