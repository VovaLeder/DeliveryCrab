using Microsoft.AspNetCore.Mvc;
using DeliveryCrab.Models;
namespace DeliveryCrab.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly ApplicationContext _context;

        public RestaurantController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurants.ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public Restaurant Get(int id)
        {
            Restaurant? restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            return restaurant;
        }

        [HttpPost]
        [Route("PostRestaurant")]
        public IActionResult Post(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();
                return Ok(restaurant);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteRestaurant")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant = _context.Restaurants.First(x => x.Id == id);
                if (restaurant != null)
                {
                    _context.Restaurants.Remove(restaurant);
                    _context.SaveChanges();
                    return Ok(id);
                }
                return BadRequest(); // Честно хз, что отправлять, если пытаться удалить юзера, id которого нет, так что пока так
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("PutRestaurant")]
        public IActionResult Put(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                Restaurant old_restaurant = _context.Restaurants.First(x => x.Id == restaurant.Id);
                old_restaurant.Id = restaurant.Id;
                old_restaurant.Name = restaurant.Name;
                old_restaurant.Icon = restaurant.Icon;
                old_restaurant.Address = restaurant.Address;

                _context.SaveChanges();
                return Ok(restaurant);
            }
            return BadRequest(ModelState);
        }
    }
}
