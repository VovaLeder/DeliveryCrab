using Microsoft.EntityFrameworkCore;

namespace DeliveryCrab.Models
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
