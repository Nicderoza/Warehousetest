using Warehouse.Common.DTOs;
namespace Warehouse.Interfaces.IServices;

public interface IOrderService
{
    Task<IEnumerable<DTOOrder>> GetAllOrdersAsync();
    Task<DTOOrder?> GetOrderByIdAsync(int id);
    Task AddOrderAsync(DTOOrder order);
    Task UpdateOrderAsync(DTOOrder order);
    Task DeleteOrderAsync(int id);
}

