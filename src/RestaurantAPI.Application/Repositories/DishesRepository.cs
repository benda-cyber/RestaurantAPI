using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Domain.Models;
using AppContext = RestaurantAPI.Persistence.AppContext;

namespace RestaurantAPI.Application.Repositories
{
    public class DishesRepository : IDishesRepository
    {
        private readonly AppContext _context;

        public DishesRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Dish> GetAsync(string id)
        {
            return await _context.Dishes.FindAsync(id);
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task CreateDishAsync(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }
    }
}
