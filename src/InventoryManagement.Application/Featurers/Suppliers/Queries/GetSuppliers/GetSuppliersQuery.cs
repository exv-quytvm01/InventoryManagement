using InventoryManagement.Application.Dto.Suppliers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Suppliers.Queries.GetSuppliers
{
    public class GetSuppliersQuery : IRequest<List<SupplierDto>>
    {
    }
}
