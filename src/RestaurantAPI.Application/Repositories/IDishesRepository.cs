using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Application.Repositories
{
    public interface IDishesRepository
    {
        Task<Dish> GetAsync(string id);

        Task<IEnumerable<Dish>> GetDishesAsync();

        Task CreateDishAsync(Dish dish);
    }
}
