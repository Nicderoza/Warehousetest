using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task<Orders> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Orders order);
        Task UpdateOrderAsync(Orders order);
        Task DeleteOrderAsync(int id);
    }
}
