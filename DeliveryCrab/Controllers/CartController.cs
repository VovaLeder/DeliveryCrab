using Microsoft.AspNetCore.Mvc;
using DeliveryCrab.Models;

namespace DeliveryCrab.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ApplicationContext _context;

        public CartController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return _context.Carts.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Cart Get(int id)
        {
            Cart? basket = _context.Carts.FirstOrDefault(x => x.Id == id);
            return basket;
        }

        [HttpGet]
        [Route("{UserId}")]
        public Cart GetByUserId(int UserId)
        {
            Cart? basket = _context.Carts.FirstOrDefault(x => x.Userid == UserId);
            return basket;
        }

        [HttpPost]
        [Route("PostCart")]
        public IActionResult Post(Cart cart)
        {
            if (ModelState.IsValid)
            {
                if (_context.Carts.Any(x => x.Productid == cart.Productid))//если запись в корзине с этим продуктом есть, то увеличиваем количество на 1
                {
                    Cart old_cart = _context.Carts.First(x => x.Productid == cart.Productid);
                    old_cart.Count = old_cart.Count + 1;
                    old_cart.Cost = old_cart.Price * old_cart.Count;
                    _context.SaveChanges();
                    return Ok(cart);
                }
                else//иначе добавляем запись с этим продуктом
                {
                    _context.Carts.Add(cart);
                    _context.SaveChanges();
                    return Ok(cart);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Cart basket = _context.Carts.First(x => x.Id == id);
                if (basket != null)
                {
                    _context.Carts.Remove(basket);
                    _context.SaveChanges();
                    return Ok(id);
                }
                return BadRequest(); // Честно хз...
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("PutCart")]
        public IActionResult Put(Cart cart)
        {
            if (ModelState.IsValid)
            {
                Cart old_cart = _context.Carts.First(x => x.Id == cart.Id);
                old_cart.Count = cart.Count;
                old_cart.Cost = old_cart.Price * cart.Count;
                _context.SaveChanges();
                return Ok(cart);
            }
            return BadRequest(ModelState);
        }
        
    }
}