using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Warehouse.Common.DTOs;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;
using Warehouse.Interfaces.IServices;

namespace Warehouse.Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly WarehouseContext _context;  // Aggiungi questa variabile membro per il contesto

        public CityService(ICityRepository cityRepository, IMapper mapper, WarehouseContext context)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _context = context;  // Assegna il contesto al membro
        }

        public async Task<IEnumerable<DTOCity>> GetAllCitiesAsync()
        {
            var cities = await _cityRepository.GetAllCitiesAsync();
            return _mapper.Map<IEnumerable<DTOCity>>(cities);  // Mappa le entità in DTO
        }

        public async Task<DTOCity> GetCityByIdAsync(int id)
        {
            var city = await _cityRepository.GetCityByIdAsync(id);
            return _mapper.Map<DTOCity>(city);  // Mappa l'entità in DTO
        }

        public async Task AddCityAsync(DTOCity city)
        {
            try
            {
                var cityEntity = _mapper.Map<Cities>(city);  // Mappa il DTO in entità
                await _cityRepository.AddAsync(cityEntity);
            }
            catch (Exception ex)
            {
                // Log dell'errore
                throw new Exception("Error adding city: " + ex.Message);
            }
        }

        public async Task UpdateCityAsync(DTOCity city)
        {
            var cityEntity = _mapper.Map<Cities>(city);  // Mappa il DTO in entità
            var existingCity = await _cityRepository.GetCityByIdAsync(city.CityID);

            if (existingCity != null)
            {
                // Se l'entità esiste già nel contesto, staccala
                _context.Entry(existingCity).State = EntityState.Detached;
            }

            // Aggiorna la città nel repository
            await _cityRepository.UpdateAsync(cityEntity);
        }

        public async Task DeleteCityAsync(int id)
        {
            await _cityRepository.DeleteAsync(id);
        }
    }
}
