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
    public class SaleOrderRepository : GenericRepository<SaleOrder>, ISaleOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleOrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SaleOrder>> GetListSaleOrders()
        {
            var items = await _context.SaleOrders
                .Include(p => p.Customer).ToListAsync();
            return items;
        }

        public Task<SaleOrder> GetSaleOrderDetail(int id)
        {
            var item = _context.SaleOrders.
                Include(p => p.Customer)
                .FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }
    }
}
