using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Application.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetAsync(string id);
        
        Task<IEnumerable<Order>> GetAllAsync(int? days);

        Task UpdateAsync(Order order);
        
        Task<Order> CreateAsync(Order order);
    }
}
