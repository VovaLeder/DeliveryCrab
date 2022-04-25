namespace DeliveryCrab.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int RestaurantId { get; set; }

        public Product(Restaurant restaurant)
        {
            RestaurantId = restaurant.Id;
        }
        
    }
}
