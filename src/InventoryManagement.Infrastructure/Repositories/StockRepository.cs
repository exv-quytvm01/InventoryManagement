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
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetListStocks()
        {
            var stocks = await _context.Stocks.Include(s => s.Product)
                .ToListAsync();
            return stocks;
        }

        public async Task<Stock> GetStockByProductId(int productId)
        {
            var stock = await _context.Stocks.Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.Product.Id == productId);
            return stock;
        }

        public async Task<Stock> GetStockDetails(int id)
        {
            var stock = await _context.Stocks.Include(s=>s.Product)
                .FirstOrDefaultAsync(s=>s.Id == id);
            return stock;
        }
    }
}
