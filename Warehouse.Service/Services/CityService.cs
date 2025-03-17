
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;
using Warehouse.Interfaces.IServices;

namespace Warehouse.Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllCitiesAsync(); // Now it matches the interface
        }

        public async Task<Cities> GetCityByIdAsync(int id)
        {
            return await _cityRepository.GetCityByIdAsync(id); // Now it exists in the repository
        }

        Task ICityService.AddCityAsync(Cities city)
        {
            throw new NotImplementedException();
        }

        Task ICityService.DeleteCityAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Cities>> ICityService.GetAllCitiesAsync()
        {
            throw new NotImplementedException();
        }

        Task<Cities> ICityService.GetCityByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task ICityService.UpdateCityAsync(Cities city)
        {
            throw new NotImplementedException();
        }
    }
}
