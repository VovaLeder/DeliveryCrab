using System;

namespace DeliveryCrab.Models
{
    
    public class Order
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public int UserId { get; set; }

        public List<Product> Products { get; set; } = new();

    }
}
