using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IRepositories;

public interface IOrderRepository : IGenericRepository<Orders>
{
    Task<Orders> GetOrderByIdAsync(int id);
    Task<IEnumerable<Orders>> GetAllOrdersAsync();
    Task AddOrderAsync(Orders order);
    Task UpdateOrderAsync(Orders order);
    Task DeleteOrderAsync(int id);

    Task<Products> GetProductByIdAsync(int productId);
    Task UpdateProductAsync(Products product);

}
