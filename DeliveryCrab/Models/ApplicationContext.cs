using Microsoft.EntityFrameworkCore;
namespace DeliveryCrab.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var CrustyCrabs = new Restaurant { Id = 1, Name = "Красти Крабс", Icon = "assets/icons/icons_crusty_crabs.svg", Address = "КрабсСтрит/1" };
            var ChumBucket = new Restaurant { Id = 2, Name = "Чам Баккет", Icon = "assets/icons/icons_chum_bucket.svg", Address = "БаккетСтрит/1" };


            modelBuilder.Entity<User>().HasData(
                new User[]
                {               
                    
                });

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant[]
                {
                    CrustyCrabs,
                    ChumBucket
                });


            modelBuilder.Entity<Product>().HasData(
                new Product[] {
                    new Product {Id = 1, Name="Крабсбургер", Image="assets/images/crabsburger.png", Price=3,Description="Вкусно", Restaurantid=1},
                    new Product {Id = 2, Name="Чамбургер", Image="assets/images/chumburger.png", Price=2.79F,Description="Чамбургер содержит бледно-бежевый чам, зажатый между булочками с кунжутом.", Restaurantid=2},
                    new Product {Id = 3, Name="Чам", Image="assets/images/chum.png", Price=0.99F,Description="Смесь всякой гнили тёмно-красного цвета", Restaurantid=2},
                    new Product {Id = 4, Name="Чам Стикс", Image="assets/images/chum_sticks.png", Price=2.00F,Description="Чам на палочке - известны своим отвратительным вкусом.", Restaurantid=2},
                    new Product {Id = 5, Name="Чам Наггетсы", Image="assets/images/chum_nuggets.png", Price=2.00F,Description="Маленькие кусочки чама овальной формы", Restaurantid=2},
                    new Product {Id = 6, Name="Чам Фрикасе", Image="assets/images/chum_fricassee.png", Price=5.00F,Description="Блюдо выглядит как обычный кусок чама, только имеет объёмную круглую форму и на вкус лучше, чем обычный чам. Его подают на маленькой круглой тарелке. Состоит из чама и секретной смеси из приправ и специй Бабушки Тэнтеклс.", Restaurantid=2},
                }
                );

        }

    }
}
