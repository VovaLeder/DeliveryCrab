using Microsoft.AspNetCore.Mvc;
using DeliveryCrab.Models;

namespace DeliveryCrab.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly ApplicationContext _context;

        public BasketController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Basket Get(int id)
        {
            Basket? basket = _context.Baskets.FirstOrDefault(x => x.Id == id);
            return basket;
        }

        [HttpGet]
        [Route("{UserId}")]
        public Basket GetByUserId(int UserId)
        {
            Basket? basket = _context.Baskets.FirstOrDefault(x => x.UserId == UserId);
            return basket;
        }

        [HttpPost]
        [Route("AddItem")]
        public IActionResult Post(Basket basket)
        {
            if (ModelState.IsValid)
            {
                if (_context.Baskets.Any(x => x.ProductId == basket.ProductId))//если запись в корзине с этим продуктом есть, то увеличиваем количество на 1
                {
                    Basket old_basket = _context.Baskets.First(x => x.Id == basket.Id);
                    old_basket.Count = old_basket.Count + 1; 
                    _context.SaveChanges();
                    return Ok(basket);
                }
                else//иначе добавляем запись с этим продуктом
                {
                    _context.Baskets.Add(basket);
                    _context.SaveChanges();
                    return Ok(basket);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public IActionResult Delete(int ProductId)
        {
            if (ModelState.IsValid)
            {
                Basket basket = _context.Baskets.First(x => x.ProductId == ProductId);
                if (basket != null)
                {
                    _context.Baskets.Remove(basket);
                    _context.SaveChanges();
                    return Ok(ProductId);
                }
                return BadRequest(); // Честно хз...
            }
            return BadRequest(ModelState);
        }
    }
}
