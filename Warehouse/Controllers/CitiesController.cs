using Microsoft.AspNetCore.Mvc;
using Warehouse.Interfaces.IServices;
using Warehouse.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warehouse.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/city
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCity>>> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);  // Restituisce una lista di DTOCity
        }

        // GET: api/city/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOCity>> GetCityById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound(new { message = "City not found" });
            }

            return Ok(city);  // Restituisce il DTO della città
        }

        // POST: api/city
        [HttpPost]
        public async Task<ActionResult> AddCity([FromBody] DTOCity cityDTO)
        {
            if (cityDTO == null)
            {
                return BadRequest(new { message = "Invalid city data" });
            }

            // Verifica se la città esiste già
            var existingCity = await _cityService.GetCityByIdAsync(cityDTO.CityID);
            if (existingCity != null)
            {
                return Conflict(new { message = "City with this ID already exists" });
            }

            await _cityService.AddCityAsync(cityDTO);
            return CreatedAtAction(nameof(GetCityById), new { id = cityDTO.CityID }, cityDTO);
        }

        // PUT: api/city/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCity(int id, [FromBody] DTOCity cityDTO)
        {
            if (cityDTO == null || id != cityDTO.CityID)
            {
                return BadRequest(new { message = "Invalid city data" });
            }

            var existingCity = await _cityService.GetCityByIdAsync(id);
            if (existingCity == null)
            {
                return NotFound(new { message = "City not found" });
            }

            await _cityService.UpdateCityAsync(cityDTO);
            return NoContent();
        }

        // DELETE: api/city/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound(new { message = "City not found" });
            }

            await _cityService.DeleteCityAsync(id);
            return NoContent();
        }
    }
}
