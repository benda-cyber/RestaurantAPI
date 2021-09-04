using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Application.Services;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Domain.Requests;

namespace RestaurantAPI.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishesService _service;
        private readonly ILogger<DishesController> _logger;

        public DishesController(IDishesService service, ILogger<DishesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogDebug($"New request to get all dishes");
            IEnumerable<Dish> result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            _logger.LogDebug($"New request get dish by ID, dishId: {id}");
            Dish result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDishAsync(CreateDishRequest request)
        {
            _logger.LogDebug($"New request to create a new dish, request: {request}");

            await _service.CreateDishAsync(request.Name, request.Price);
            return NoContent();
        }
    }
}