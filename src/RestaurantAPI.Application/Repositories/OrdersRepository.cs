using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Domain.Models;
using AppContext = RestaurantAPI.Persistence.AppContext;

namespace RestaurantAPI.Application.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppContext _context;

        public OrdersRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Order> GetAsync(string id)
        {
            return await _context.Orders
                .Include(x => x.Dishes)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(int? days)
        {
            IQueryable<Order> query = _context.Orders.Include(order => order.Dishes);

            if (days.HasValue)
            {
                query = query.Where(order => order.CreatedTime >= DateTime.Now.AddDays(-days.Value));
            }

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Order> CreateAsync(Order order)
        {
            EntityEntry<Order> result = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}