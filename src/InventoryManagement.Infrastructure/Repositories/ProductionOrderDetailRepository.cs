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
    public class ProductionOrderDetailRepository :
        GenericRepository<ProductionOrderDetail>, IProductionOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductionOrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductionOrderDetail>> GetListProOrderDetails()
        {
            var items = await _context.ProductionOrderDetails
                .Include(p => p.Product)
                .Include(p => p.ProductionOrder)
                .ToListAsync();
            return items;
        }

        public async Task<ProductionOrderDetail> GetProOrderDetails(int id)
        {
            var item = await _context.ProductionOrderDetails
                .Include(p => p.Product)
                .Include(p => p.ProductionOrder)
                .FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<List<ProductionOrderDetail>> GetProOrderDetailsByProOrder(int id)
        {
            var items = await _context.ProductionOrderDetails
                .Where(p=>p.ProductionOrderId == id)
                .ToListAsync();
            return items;
        }
    }
}
