using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;

namespace Warehouse.Repository.Repositories;

public class ProductRepository : GenericRepository<Products>, IProductRepository
{
    public ProductRepository(WarehouseContext context) : base(context)
    {
    }

    public Task AddProductAsync(Products product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Products>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Products?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
    }

    public Task<Products> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(Products product)
    {
        throw new NotImplementedException();
    }
}

