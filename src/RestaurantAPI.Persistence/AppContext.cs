using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Persistence
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Dish> Dishes { get; set; }
    }
}