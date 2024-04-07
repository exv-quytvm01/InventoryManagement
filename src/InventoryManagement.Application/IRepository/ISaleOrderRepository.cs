using ExampleProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IRepository
{
    public interface ISaleOrderRepository : IGenericRepository<SaleOrder>
    {
        Task<SaleOrder> GetSaleOrderDetail(int id);
        Task<List<SaleOrder>> GetListSaleOrders();
    }
}
