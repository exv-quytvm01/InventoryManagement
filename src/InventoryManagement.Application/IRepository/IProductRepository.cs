using ExampleProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductDetails(int id);
        Task<List<Product>> GetListProducts();
    }
}
