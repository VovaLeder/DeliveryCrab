using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCrab.Models
{
    
    public class Order
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string? Address { get; set; }
        public int Userid { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

    }
}
