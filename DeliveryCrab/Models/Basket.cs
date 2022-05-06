using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCrab.Models
{
    public class Basket
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public int Count { get; set; }
    }
}
