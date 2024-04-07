using InventoryManagement.Application.Dto.Customers;
using InventoryManagement.Application.Dto.SaleOrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.SaleOrders
{
    public class DetailSaleOrderDto
    {
        public SaleOrderDto SaleOrderDto;
        public List<SaleOrderDetailDto> Details { get; set; }
    }
}
