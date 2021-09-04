using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Application.Services
{
    public interface IDishesService
    {
        Task<IEnumerable<Dish>> GetAllAsync();

        Task<Dish> GetAsync(string id);

        Task CreateDishAsync(string name, double price);
    }
}