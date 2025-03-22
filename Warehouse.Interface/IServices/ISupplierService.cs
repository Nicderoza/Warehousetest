using Warehouse.Common.DTOs;
using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IServices
{
    public interface ISupplierService
    {
        Task<IEnumerable<DTOSupplier>> GetAllSuppliersAsync();
        Task<DTOSupplier> GetSupplierByIdAsync(int id);
        Task AddSupplierAsync(DTOSupplier supplier);
        Task UpdateSupplierAsync(DTOSupplier supplier);
        Task DeleteSupplierAsync(int id);
    }
}
