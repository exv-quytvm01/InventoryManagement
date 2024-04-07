using ExampleProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IRepository
{
    public interface ISaleOrderDetailRepository : IGenericRepository<SaleOrderDetail>
    {
        Task<SaleOrderDetail> GetSaleOrderDetails(int id);
        Task<List<SaleOrderDetail>> GetListSaleOrderDetails();
        Task<List<SaleOrderDetail>> GetSaleOrderDetailsBySaleOrder(int id);
    }
}
