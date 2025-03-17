using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IRepositories;

public interface ISupplierRepository : IGenericRepository<Suppliers>
{
    Task AddSupplierAsync(Suppliers supplier);
    Task DeleteSupplierAsync(int id);
    Task<IEnumerable<Suppliers>> GetAllSuppliersAsync();
    Task<Suppliers> GetSupplierByIdAsync(int id);
    Task UpdateSupplierAsync(Suppliers supplier);
}
