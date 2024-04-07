using InventoryManagement.Application.Dto.ProductOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetDetailPro
{
    public class GetDetailProOrderQuery : IRequest<DetailProductOrderDto>
    {
        public int Id { get; set; }
    }
}
