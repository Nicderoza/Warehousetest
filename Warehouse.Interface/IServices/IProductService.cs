using Warehouse.Common.DTOs;

namespace Warehouse.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<DTOProduct>> GetAllProductsAsync();  // Restituisce una lista di DTOProduct
        Task<DTOProduct> GetProductByIdAsync(int id);        // Restituisce un DTOProduct
        Task AddProductAsync(DTOProduct product);             // Accetta un DTOProduct
        Task UpdateProductAsync(DTOProduct product);          // Accetta un DTOProduct
        Task DeleteProductAsync(int id);                       // Accetta solo l'ID per eliminare
    }
}
