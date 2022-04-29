using Microsoft.EntityFrameworkCore;
namespace DeliveryCrab.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            /*Database.EnsureDeleted()*/;//Чтоб работала регистрация на сессии, нужно закомментить удаление бд)
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User {Id = 1, Firstname="Василий", Lastname="Малютин", Age=23, Login="vasiliym", Email="maliutin.vas@yandex.ru", Password="vas123987"},
                    
                });

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant[]
                {
                    new Restaurant {Id = 1, Name="CCrabs", Icon="icon.png", Address="adress", Userid=1},
                });


            modelBuilder.Entity<Product>().HasData(
                new Product[] {
                    new Product {Id = 1, Name="Burger", Icon="icon.png", Price=3,Description="Tasty", RestaurantId=1}
                }
                );

        }

    }
}
