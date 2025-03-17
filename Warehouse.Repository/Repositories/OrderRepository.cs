using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;

namespace Warehouse.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        public OrderRepository(WarehouseContext context) : base(context)
        {
        }

        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddOrderAsync(Orders order)
        {
            await AddAsync(order);
        }

        public async Task UpdateOrderAsync(Orders order)
        {
            await UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await GetOrderByIdAsync(id);
            if (order != null)
            {
                await DeleteAsync(order);
            }
        }

        private async Task DeleteAsync(Orders order)
        {
            throw new NotImplementedException();
        }
    }
}