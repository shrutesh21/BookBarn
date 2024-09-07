using BookBarn_Api.Model.Data;
using BookBarn_Api.Model.Entities;
using BookBarn_Api.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBarn_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository db;

        public OrdersController(IOrdersRepository db)
        {
            this.db = db;
        }

        // Get order by ID
        [HttpGet]
        [Route("{orderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrdersById(int orderId)
        {
            var orders = await db.GetOrdersById(orderId);
            if (orders == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        // Get admin orders (non-delivered)
        [HttpGet]
        [Route("admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminOrders()
        {
            var orders = await db.GetAdminOrders();
            if (orders == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Select all orders where status is not "Delivered"
            var allOrders = orders.Where(o => o.OrderStatus != "Delivered").ToList();

            return Ok(allOrders);
        }

        // Get user orders (non-delivered)
        [HttpGet]
        [Route("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var orders = await db.GetUserOrders(userId);
            if (orders == null || !orders.Any())
                return NotFound("Order not found for the given ID");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Select all orders where status is not "Delivered"
            var allOrders = orders.Where(o => o.OrderStatus != "Delivered").ToList();

            return Ok(allOrders);
        }

        // Add a new order
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await db.AddOrder(order);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
