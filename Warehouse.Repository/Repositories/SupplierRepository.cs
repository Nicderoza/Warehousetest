using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;

namespace Warehouse.Repository.Repositories
{
    public class SupplierRepository : GenericRepository<Suppliers>, ISupplierRepository
    {
        public SupplierRepository(WarehouseContext context) : base(context)
        {
        }

        public Task AddSupplierAsync(Suppliers supplier)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSupplierAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Suppliers>> GetAllSuppliersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Suppliers?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }

        public Task<Suppliers> GetSupplierByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSupplierAsync(Suppliers supplier)
        {
            throw new NotImplementedException();
        }
    }
}

