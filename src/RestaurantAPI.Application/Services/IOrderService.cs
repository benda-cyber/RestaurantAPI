using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Application.Services
{
    public interface IOrderService
    {
        Task<Order> GetAsync(string id);

        Task<IEnumerable<Order>> GetAllAsync(int? days);

        Task AddDishToOrderAsync(string orderId, string dishId);
        
        Task MarkPaidAsync(string orderId);
        
        Task CreateOrderAsync(bool isPaid, ICollection<Dish> dishes);
    }
}