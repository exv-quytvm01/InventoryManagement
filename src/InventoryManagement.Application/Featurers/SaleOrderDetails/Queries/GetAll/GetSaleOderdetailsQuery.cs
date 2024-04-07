using InventoryManagement.Application.Dto.SaleOrderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrderDetails.Queries.GetAll
{
    public class GetSaleOderdetailsQuery : IRequest<List<SaleOrderDetailDto>>
    {
    }
}
