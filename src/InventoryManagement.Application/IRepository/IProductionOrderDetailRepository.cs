using ExampleProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IRepository
{
    public interface IProductionOrderDetailRepository : IGenericRepository<ProductionOrderDetail>
    {
        Task<ProductionOrderDetail> GetProOrderDetails(int id);
        Task<List<ProductionOrderDetail>> GetListProOrderDetails();
        Task<List<ProductionOrderDetail>> GetProOrderDetailsByProOrder(int id);
    }
}
