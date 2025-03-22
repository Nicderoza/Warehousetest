using Warehouse.Common.DTOs;

namespace Warehouse.Interfaces.IServices
{
    public interface ICityService
    {
        Task<IEnumerable<DTOCity>> GetAllCitiesAsync();  // Restituisce i DTOCity
        Task<DTOCity> GetCityByIdAsync(int id);          // Restituisce un DTOCity
        Task AddCityAsync(DTOCity city);                  // Accetta un DTOCity
        Task UpdateCityAsync(DTOCity city);               // Accetta un DTOCity
        Task DeleteCityAsync(int id);                     // Accetta solo l'ID
    }
}
