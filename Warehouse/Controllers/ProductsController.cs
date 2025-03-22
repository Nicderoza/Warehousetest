using Microsoft.AspNetCore.Mvc;
using Warehouse.Common.DTOs;
using Warehouse.Interfaces.IServices;

namespace Warehouse.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOProduct>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);  // Restituisce la lista dei DTO
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOProduct>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);  // Restituisce il DTO del prodotto
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] DTOProduct dtoProduct)
        {
            if (dtoProduct == null)
            {
                return BadRequest("Product data is null");
            }

            await _productService.AddProductAsync(dtoProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = dtoProduct.ProductID }, dtoProduct);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] DTOProduct dtoProduct)
        {
            if (id != dtoProduct.ProductID)
            {
                return BadRequest("Product ID mismatch");
            }

            await _productService.UpdateProductAsync(dtoProduct);
            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
