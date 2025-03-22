using Microsoft.AspNetCore.Mvc;
using Warehouse.Common.DTOs;
using Warehouse.Interfaces.IServices;

namespace Warehouse.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOSupplier>>> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        // GET: api/suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOSupplier>> GetSupplierById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        // POST: api/suppliers
        [HttpPost]
        public async Task<ActionResult> AddSupplier(DTOSupplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest("Supplier data is null");
            }

            await _supplierService.AddSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetSupplierById), new { id = supplier.SupplierID }, supplier);
        }

        // PUT: api/suppliers/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSupplier(int id, DTOSupplier supplier)
        {
            if (id != supplier.SupplierID)
            {
                return BadRequest("Supplier ID mismatch");
            }

            await _supplierService.UpdateSupplierAsync(supplier);
            return NoContent();
        }

        // DELETE: api/suppliers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            await _supplierService.DeleteSupplierAsync(id);
            return NoContent();
        }
    }
}
