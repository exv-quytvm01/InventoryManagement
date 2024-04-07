using InventoryManagement.Application.Dto.SaleOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrderDetails.Queries.GetById
{
    public class GetSaleOderDetailQuery : IRequest<SaleOrderDto>
    {
        public int Id { get; set; }
    }
}
