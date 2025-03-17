using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IRepositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Categories>> GetAllCategoriesAsync();
    Task<Categories> GetCategoryByIdAsync(int id);
    Task<Categories> GetByNameAsync(string name);
    Task AddCategoryAsync(Categories category);
    Task UpdateCategoryAsync(Categories category);
    Task DeleteCategoryAsync(int id);
}


