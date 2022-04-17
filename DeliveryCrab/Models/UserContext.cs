using Microsoft.EntityFrameworkCore;
namespace DeliveryCrab.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { 
                        Id = 1, 
                        FirstName = "Василий", 
                        LastName = "Малютин",
                        Age = 22,
                        Email = "maliutin.vas@yandex.ru",
                        Login = "vasiliym",
                        Password = "vas123987"
                            }
                    
            );
        }
    }
}
