using ExampleProject.Core.Entities;
using InventoryManagement.Application.IRepository;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductionOrderRepository : GenericRepository<ProductionOrder>, IProductionOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductionOrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductionOrder>> GetListProductionOrders()
        {
            var items = await _context.ProductionOrders.Include(p=>p.Supplier)
                .ToListAsync();
            return items;
        }

        public async Task<ProductionOrder> GetProductionOrderDetails(int id)
        {
            var item = await _context.ProductionOrders.Include(p=>p.Supplier)
                .FirstOrDefaultAsync(p=>p.Id == id);
            return item;
        }
    }
}
