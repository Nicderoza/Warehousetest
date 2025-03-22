using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categories>> GetAllCategoriesAsync();
        Task<Categories> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Categories category);
        Task UpdateCategoryAsync(Categories category);
        Task DeleteCategoryAsync(int id);
    }
}
