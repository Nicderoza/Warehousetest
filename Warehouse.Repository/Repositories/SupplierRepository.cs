using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Models;
using Warehouse.Data;
using Warehouse.Interfaces.IRepositories;
using Warehouse.Repository.Repositories;

public class SupplierRepository : GenericRepository<Suppliers>, ISupplierRepository
{
    public SupplierRepository(WarehouseContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Suppliers>> GetAllSuppliersAsync()
    {
        return await _dbSet.ToListAsync(); // Restituisce tutti i fornitori
    }

    public async Task<Suppliers> GetSupplierByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.SupplierID == id); // Trova un fornitore per ID
    }

    public async Task AddSupplierAsync(Suppliers supplier)
    {
        await _dbSet.AddAsync(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSupplierAsync(Suppliers supplier)
    {
        _dbSet.Update(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSupplierAsync(int id)
    {
        var supplier = await _dbSet.FindAsync(id);
        if (supplier != null)
        {
            _dbSet.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
