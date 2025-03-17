using Microsoft.AspNetCore.Mvc;
using Warehouse.Interfaces.IServices;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOOrder>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderDTOs = orders.Select(o => new DTOOrder
            {
                IDOrder = o.IDOrder,
                OrderDate = o.OrderDate,
                IDClient = o.IDClient,
                IDCourier = o.IDCourier,
                Status = o.Status,
                IdProduct = o.IdProduct
            });
            return Ok(orderDTOs);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOOrder>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDTO = new DTOOrder
            {
                IDOrder = order.IDOrder,
                OrderDate = order.OrderDate,
                IDClient = order.IDClient,
                IDCourier = order.IDCourier,
                Status = order.Status,
                IdProduct = order.IdProduct
            };

            return Ok(orderDTO);
        }
    }
}
