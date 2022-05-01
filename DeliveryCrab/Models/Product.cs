namespace DeliveryCrab.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } //ссылка на картинку
        public float Price { get; set; }
        public string Description { get; set; }

        public int RestaurantId { get; set; } // внешний ключ
        public Restaurant? Restaurant { get; set; }  // навигационное свойство(добавляет каскадное удаление)
        
    }
}
