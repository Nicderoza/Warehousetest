using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;

namespace Warehouse.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(WarehouseContext context) : base(context) { }

        public override async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Orders)
                .ToListAsync();
        }

        public override async Task<Products> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Orders)
                .FirstOrDefaultAsync(p => p.ProductID == id);
        }
    }
}
