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
    public class SaleOrderDetailRepository : GenericRepository<SaleOrderDetail>, ISaleOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleOrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SaleOrderDetail>> GetListSaleOrderDetails()
        {
            var items = await _context.SaleOrderDetails
                .Include(i => i.Product)
                .Include(i=> i.SaleOrder)
                .ToListAsync();
            return items;
        }

        public async Task<SaleOrderDetail> GetSaleOrderDetails(int id)
        {
            var item = await  _context.SaleOrderDetails
                .Include(i => i.Product)
                .Include(i => i.SaleOrder)
                .FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public async Task<List<SaleOrderDetail>> GetSaleOrderDetailsBySaleOrder(int id)
        {
            var items = await _context.SaleOrderDetails
                .Where(p=>p.SaleOrderId == id)
                .ToListAsync();
            return items;
        }
    }
}
