using ExampleProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IRepository
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        Task<Stock> GetStockDetails(int id);
        Task<List<Stock>> GetListStocks();
        Task<Stock> GetStockByProductId(int productId);
    }
}
