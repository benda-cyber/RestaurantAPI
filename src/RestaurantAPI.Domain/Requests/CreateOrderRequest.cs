using System.Collections.Generic;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Domain.Requests
{
    public class CreateOrderRequest
    {
        public bool IsPaid { get; set; }

        public ICollection<Dish> Dishes { get; set; }

        public override string ToString()
        {
            return $"{nameof(IsPaid)}: {IsPaid}, Dishes Count: {Dishes.Count}";
        }
    }
}