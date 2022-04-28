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
            Database.EnsureDeleted();
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User {Id = 1, Firstname="Tom", Lastname="q", Age=12, Login="as", Email="a@a.a", Password="pass"},
                    new User {Id = 2, Firstname="Toma", Lastname="qa", Age=122, Login="asa", Email="a@a.aa", Password="passa"},
                    new User {Id = 3, Firstname="Toms", Lastname="qs", Age=122, Login="ass", Email="a@a.as", Password="passs"},
                    new User {Id = 4, Firstname="Toms", Lastname="qs", Age=122, Login="aass", Email="a@a.as", Password="passs"}
                });

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant[]
                {
                    new Restaurant {Id = 1, Name="CCrabs", Icon="icon.png", Address="adress", UserId=1},
                });


            modelBuilder.Entity<Product>().HasData(
                new Product[] {
                    new Product {Id = 1, Name="Burger", Icon="icon.png", Price=3,Description="Tasty", RestaurantId=1}
                }
                );

        }

    }
}
