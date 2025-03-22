using Microsoft.AspNetCore.Mvc;
using Warehouse.Interfaces.IServices;
using Warehouse.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warehouse.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOOrder>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOOrder>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }
            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] DTOOrder orderDTO)
        {
            if (orderDTO == null)
            {
                return BadRequest(new { message = "Invalid order data" });
            }

            await _orderService.AddOrderAsync(orderDTO); // errore 1503 su orderDTO
            return CreatedAtAction(nameof(GetOrderById), new { id = orderDTO.OrderID }, orderDTO);
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromBody] DTOOrder orderDTO)
        {
            if (orderDTO == null || id != orderDTO.OrderID)
            {
                return BadRequest(new { message = "Invalid order data" });
            }

            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound(new { message = "Order not found" });
            }

            await _orderService.UpdateOrderAsync(orderDTO);  // errore 1503 su orderDTO
            return NoContent();
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }

            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
