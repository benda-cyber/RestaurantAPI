namespace RestaurantAPI.Domain.Requests
{
    public class CreateDishRequest
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}