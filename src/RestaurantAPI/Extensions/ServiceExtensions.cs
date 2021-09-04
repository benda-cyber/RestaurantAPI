using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RestaurantAPI.Application.Repositories;
using RestaurantAPI.Application.Services;
using RestaurantAPI.Persistence;

namespace RestaurantAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDishesService, DishesService>();
        }

        public static void AddMyRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDishesRepository, DishesRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
        }

        public static void AddMyDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Default"));
            });
        }

        public static void AddMySwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "JonesTest", Version = "v1"});
            });
        }
    }
}