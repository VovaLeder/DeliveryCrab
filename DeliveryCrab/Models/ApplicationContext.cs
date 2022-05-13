using Microsoft.EntityFrameworkCore;
namespace DeliveryCrab.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
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
                    new User {Id = 1, Firstname = "Admin", Lastname = "Admin", Age = 25, Login = "admin", Email = "delivery.crab.admin@bottom.com", Password = "admin"}
                });

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant[]
                {
                    CrustyCrabs,
                    ChumBucket
                });

            var ai = "assets/images/";
            modelBuilder.Entity<Product>().HasData(
                new Product[] {
                    new Product {Id = 1, Name="Крабсбургер", Image=ai+"crabsburger.png", Price=1.25F,Description="Вкусно", Restaurantid=1},
                    new Product {Id = 2, Name="Чамбургер", Image=ai+"chumburger.png", Price=2.79F,Description="Чамбургер содержит бледно-бежевый чам, зажатый между булочками с кунжутом.", Restaurantid=2},
                    new Product {Id = 3, Name="Чам", Image=ai+"chum.png", Price=0.99F,Description="Смесь всякой гнили тёмно-красного цвета", Restaurantid=2},
                    new Product {Id = 4, Name="Чам Стикс", Image=ai+"chum_sticks.png", Price=2.00F,Description="Чам на палочке - известны своим отвратительным вкусом.", Restaurantid=2},
                    new Product {Id = 5, Name="Чам Наггетсы", Image=ai+"chum_nuggets.png", Price=2.00F,Description="Маленькие кусочки чама овальной формы", Restaurantid=2},
                    new Product {Id = 6, Name="Чам Фрикасе", Image=ai+"chum_fricassee.png", Price=5.00F,Description="Блюдо выглядит как обычный кусок чама, только имеет объёмную круглую форму и на вкус лучше, чем обычный чам. Его подают на маленькой круглой тарелке. Состоит из чама и секретной смеси из приправ и специй Бабушки Тэнтеклс.", Restaurantid=2},
                    new Product {Id = 7, Name="Красти Пицца", Image=ai+"krusty_pizza.png", Price=3.00F,Description="Красти пицца с 7 кусочками сочной пепперони и грибами",Restaurantid=1},
                    new Product {Id = 8, Name="Красти Кидс Мил", Image=ai+"krusty_kids_meal.png", Price=1.99F,Description="Это коробочка содержащая пищу немного меньшего размера и игрушку.",Restaurantid=1},
                    new Product {Id = 9, Name="Кусочки кораллов", Image=ai+"coral_bits.png",Price=1.95F,Description="Маленькие кусочки розовых кораллов",Restaurantid=1},
                    new Product {Id =10, Name="Ультра Крабби Суприм Кинг-сайз", Image=ai+"ksuks.png", Price=2.99F, Description="Более крупный крабсбургер на палочке, дважды обжаренный в кляре",Restaurantid=1}
                }
                );

        }

    }
}
