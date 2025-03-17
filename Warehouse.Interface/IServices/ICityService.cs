using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IServices
{
    public interface ICityService
    {
        Task<IEnumerable<Cities>> GetAllCitiesAsync();
        Task<Cities> GetCityByIdAsync(int id);
        Task AddCityAsync(Cities city);
        Task UpdateCityAsync(Cities city);
        Task DeleteCityAsync(int id);
    }
}
