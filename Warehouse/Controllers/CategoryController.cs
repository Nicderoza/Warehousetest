using Microsoft.AspNetCore.Mvc;
using Warehouse.Interfaces.IServices;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCategory>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoryDTOs = categories.Select(c => new DTOCategory { IdCategory = c.IDCategory, Name = c.CategoryName });
            return Ok(categoryDTOs);
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOCategory>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDTO = new DTOCategory { IdCategory = category.IDCategory, Name = category.CategoryName };
            return Ok(categoryDTO);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] DTOCategory dtoCategory)
        {
            var category = new Categories
            {
                IDCategory = dtoCategory.IdCategory,
                CategoryName = dtoCategory.Name
            };

            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.IDCategory }, dtoCategory);
        }

        // PUT: api/Category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] DTOCategory dtoCategory)
        {
            if (id != dtoCategory.IdCategory)
            {
                return BadRequest("ID mismatch");
            }

            var category = new Categories
            {
                IDCategory = dtoCategory.IdCategory,
                CategoryName = dtoCategory.Name
            };

            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
