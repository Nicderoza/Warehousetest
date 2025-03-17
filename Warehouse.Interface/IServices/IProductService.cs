using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int id);
        Task AddProductAsync(Products product);
        Task UpdateProductAsync(Products product);
        Task DeleteProductAsync(int id);
    }
}
