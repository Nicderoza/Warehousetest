using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IRepositories;

public interface IProductRepository : IGenericRepository<Products>
{
    Task AddProductAsync(Products product);
    Task DeleteProductAsync(int id);
    Task<IEnumerable<Products>> GetAllProductsAsync();
    Task<Products?> GetByNameAsync(string name);
    Task<Products> GetProductByIdAsync(int id);
    Task UpdateProductAsync(Products product);
}
