using InventoryManagement.Application.Dto.ProductionOrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto.ProductOrders
{
    public class CreateProductOrderDto
    {
        public int SupplierId { get; set; }
        public DateTime Date { get; set; }
        public float? total_anmt { get; set; }
        public virtual List<CreateProductionOrderDetailDto> 
            ListProductOrders { get; set; } = new List<CreateProductionOrderDetailDto>();
    }
}
