using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;

namespace Warehouse.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository
    {
        public CategoryRepository(WarehouseContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Categories> GetCategoryByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<Categories> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.CategoryName == name);
        }
        public async Task AddCategoryAsync(Categories category)
        {
            await AddAsync(category);
        }
        public async Task UpdateCategoryAsync(Categories category)
        {
            await UpdateAsync(category);
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
            {
                await DeleteAsync(category);
            }
        }

        private async Task DeleteAsync(Categories category)
        {
            throw new NotImplementedException();
        }
    }
}
