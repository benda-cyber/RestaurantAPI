using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Application.Repositories;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Application.Services
{
    public class DishesService : IDishesService
    {
        private readonly IDishesRepository _repository;
        private readonly ILogger<IDishesService> _logger;


        public DishesService(IDishesRepository repository, ILogger<IDishesService> logger)
        {
            _repository = repository;
            _logger = logger;

        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            return await _repository.GetDishesAsync();
        }

        public async Task<Dish> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task CreateDishAsync(string name, double price)
        {
            var dish = new Dish
            {
                Name = name,
                Price = price
            };

            await _repository.CreateDishAsync(dish);
            _logger.LogInformation($"Dish has been created with id '{dish.Id}'");

        }
    }
}