namespace DeliveryCrab.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; } //ссылка на картинку
        public int Price { get; set; }
        public string Description { get; set; }

        public int RestaurantId { get; set; } // внешний ключ
        public Restaurant Restaurant { get; set; }  // навигационное свойство(добавляет каскадное удаление)
        
    }
}
