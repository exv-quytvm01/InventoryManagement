using InventoryManagement.Application.Dto.ProductionOrderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrderDetails.Queries.GetById
{
    public class GetProductionOrderDetailQuery : IRequest<ProductionOrderDetailDto>
    {
        public int Id { get; set; }
    }
}
