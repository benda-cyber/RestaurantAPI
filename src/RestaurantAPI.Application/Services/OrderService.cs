using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Application.Repositories;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Exceptions;

namespace RestaurantAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IDishesRepository _dishesRepository;
        private readonly ILogger<IOrderService> _logger;

        public OrderService(IOrdersRepository ordersRepository, IDishesRepository dishesRepository, ILogger<IOrderService> logger)
        {
            _ordersRepository = ordersRepository;
            _dishesRepository = dishesRepository;
            _logger = logger;
        }

        public async Task<Order> GetAsync(string id)
        {
            return await _ordersRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(int? days)
        {
            return await _ordersRepository.GetAllAsync(days);
        }

        public async Task AddDishToOrderAsync(string orderId, string dishId)
        {
            Order order = await _ordersRepository.GetAsync(orderId);

            if (order == null)
            {
                var error = $"Order '{orderId}' could not be found";
                _logger.LogError(error);
                throw new NotFoundException(error);
            }

            Dish dish = await _dishesRepository.GetAsync(dishId);

            if (dish == null)
            {
                var error = $"Dish '{dishId}' could not be found";
                _logger.LogError(error);
                throw new NotFoundException(error);
            }

            order.Dishes.Add(dish);
            order.TotalPrice = order.Dishes.Sum(d => d.Price);
            await _ordersRepository.UpdateAsync(order);
            _logger.LogInformation($"Dish '{dish.Name}' has been added to orderId '{orderId}'");
            _logger.LogInformation($"Order totalPrice has been updated to '{order.TotalPrice}'");
        }

        public async Task MarkPaidAsync(string orderId)
        {
            Order order = await _ordersRepository.GetAsync(orderId);

            if (order == null)
            {
                var error = $"Order '{orderId}' could not be found";
                _logger.LogError(error);
                throw new NotFoundException(error);
            }

            order.IsPaid = true;

            await _ordersRepository.UpdateAsync(order);
            _logger.LogInformation($"Order '{orderId}' has been mark as paid");
        }

        public async Task CreateOrderAsync(bool isPaid, ICollection<Dish> dishes)
        {
            var order = new Order
            {
                Dishes = dishes,
                IsPaid = isPaid,
                CreatedTime = DateTime.Now,
                TotalPrice = dishes.Sum(dish => dish.Price)
            };

            Order createdOrder = await _ordersRepository.CreateAsync(order);
            _logger.LogInformation($"Order has been created with id '{createdOrder.Id}'");
        }
    }
}