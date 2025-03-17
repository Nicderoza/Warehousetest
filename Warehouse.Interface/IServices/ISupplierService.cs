using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IServices
{
    public interface ISupplierService
    {
        Task<IEnumerable<Suppliers>> GetAllSuppliersAsync();
        Task<Suppliers> GetSupplierByIdAsync(int id);
        Task AddSupplierAsync(Suppliers supplier);
        Task UpdateSupplierAsync(Suppliers supplier);
        Task DeleteSupplierAsync(int id);
    }
}
