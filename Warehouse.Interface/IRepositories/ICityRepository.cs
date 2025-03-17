using Warehouse.Data.Models;

namespace Warehouse.Interfaces.IRepositories;

public interface ICityRepository : IGenericRepository<Cities>
{
    Task<IEnumerable<Cities>> GetAllCitiesAsync();
    Task<Cities> GetCityByIdAsync(int id);
}


