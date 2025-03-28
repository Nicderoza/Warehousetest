﻿using Microsoft.AspNetCore.Mvc;
using Warehouse.Interfaces.IServices;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;

namespace Warehouse.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCategory>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoryDTOs = categories.Select(c => new DTOCategory { CategoryID = c.CategoryID, CategoryName = c.CategoryName });
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

            var categoryDTO = new DTOCategory { CategoryID = category.CategoryID, CategoryName = category.CategoryName };
            return Ok(categoryDTO);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] DTOCategory dtoCategory)
        {
            var category = new Categories
            {
                CategoryID = dtoCategory.CategoryID,
                CategoryName = dtoCategory.CategoryName
            };

            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryID }, dtoCategory);
        }

        // PUT: api/Category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] DTOCategory dtoCategory)
        {
            if (id != dtoCategory.CategoryID)
            {
                return BadRequest("ID mismatch");
            }

            var category = new Categories
            {
                CategoryID = dtoCategory.CategoryID,
                CategoryName = dtoCategory.CategoryName
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
