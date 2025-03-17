using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IServices;
using Warehouse.Common.DTOs;

namespace Warehouse.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/city
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCity>>> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            var cityDTOs = cities.Select(c => new DTOCity { IdCity = c.IDCity, Name = c.Name });

            return Ok(cityDTOs);
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

            var cityDTO = new DTOCity { IdCity = city.IDCity, Name = city.Name };
            return Ok(cityDTO);
        }

        // POST: api/city
        [HttpPost]
        public async Task<ActionResult> AddCity([FromBody] DTOCity cityDTO)
        {
            if (cityDTO == null)
            {
                return BadRequest(new { message = "Invalid city data" });
            }

            var city = new Cities { IDCity = cityDTO.IdCity, Name = cityDTO.Name };
            await _cityService.AddCityAsync(city);

            return CreatedAtAction(nameof(GetCityById), new { id = city.IDCity }, cityDTO);
        }

        // PUT: api/city/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCity(int id, [FromBody] DTOCity cityDTO)
        {
            if (cityDTO == null || id != cityDTO.IdCity)
            {
                return BadRequest(new { message = "Invalid city data" });
            }

            var existingCity = await _cityService.GetCityByIdAsync(id);
            if (existingCity == null)
            {
                return NotFound(new { message = "City not found" });
            }

            existingCity.Name = cityDTO.Name;
            await _cityService.UpdateCityAsync(existingCity);

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

