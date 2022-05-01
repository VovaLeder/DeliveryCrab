namespace DeliveryCrab.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Address { get; set; }

        public List<Product> Products { get; set; } = new();// навигационное свойство(НС)

    }
}
