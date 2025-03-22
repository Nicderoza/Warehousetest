using System;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;

namespace Warehouse.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        private readonly WarehouseContext _context;

        public OrderRepository(WarehouseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            return await _dbSet
                .Include(o => o.Product)
                .Include(o => o.User)
                .ToListAsync();
        }

        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await _dbSet
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.OrderID == id);
        }

        public async Task<Products> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task AddOrderAsync(Orders order)
        {
            await AddAsync(order);
        }

        public async Task UpdateOrderAsync(Orders order)
        {
            _dbSet.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Products product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await GetOrderByIdAsync(id);
            if (order != null)
            {
                await DeleteAsync(order.OrderID); // Se DeleteAsync accetta un ID oppure await DeleteAsync(order); // Se DeleteAsync accetta un oggetto
            }
        }

    }
}
