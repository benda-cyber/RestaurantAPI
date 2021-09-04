using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Application.Services;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Domain.Requests;

namespace RestaurantAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService service, ILogger<OrdersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersAsync([FromQuery] int? days)
        {
            _logger.LogDebug($"New request to get all orders");

            if (days.HasValue)
            {
                _logger.LogDebug($"{nameof(days)}: {days.Value}");
            }

            IEnumerable<Order> result = await _service.GetAllAsync(days);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetAsync(string id)
        {
            _logger.LogDebug($"New request get order by ID, orderId: {id}");
            Order result = await _service.GetAsync(id);

            return Ok(result);
        }

        [HttpPut("{orderId}/dishes/{dishId}")]
        public async Task<ActionResult<Order>> AddDishToOrderAsync(string orderId, string dishId)
        {
            _logger.LogDebug($"New request add a dish to an order as paid, orderId: {orderId}, dishId: {dishId}");
            await _service.AddDishToOrderAsync(orderId, dishId);
            
            return NoContent();
        }

        [HttpPut("{orderId}/payment")]
        public async Task<ActionResult<Order>> MarkPaidAsync(string orderId)
        {
            _logger.LogDebug($"New request to mark order as paid, orderId: {orderId}");
            await _service.MarkPaidAsync(orderId);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrderAsync(CreateOrderRequest request)
        {
            _logger.LogDebug($"New request to create a new order, request: {request}");
            await _service.CreateOrderAsync(request.IsPaid, request.Dishes);

            return NoContent();
        }
    }
}