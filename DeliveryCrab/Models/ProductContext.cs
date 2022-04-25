using Microsoft.EntityFrameworkCore;

namespace DeliveryCrab.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
