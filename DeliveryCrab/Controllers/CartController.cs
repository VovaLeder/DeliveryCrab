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
        //[HttpPost]
        //[Route("PostBasket")]
        //public IActionResult Post(Basket basket, int count)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_context.Baskets.Any(x => x.Productid == basket.Productid))//если запись в корзине с этим продуктом есть, то увеличиваем количество на 1
        //        {
        //            Basket old_basket = _context.Baskets.First(x => x.Id == basket.Id);
        //            old_basket.Count = old_basket.Count + count;
        //            _context.SaveChanges();
        //            return Ok(basket);
        //        }
        //        else//иначе добавляем запись с этим продуктом
        //        {
        //            _context.Baskets.Add(basket);
        //            _context.SaveChanges();
        //            return Ok(basket);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpPost]
        //[Route("PostBasketAlternative")]
        //public IActionResult PostAlternative(int userId, int productId, int count)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var baskets = _context.Baskets.Where(x => x.Productid == productId);
        //        Basket basket = baskets.First(x => x.Userid == userId);
        //        if (basket != null)//если запись в корзине с этим продуктом есть, то увеличиваем количество на 1
        //        {
        //            basket.Count = basket.Count + count;
        //            _context.SaveChanges();
        //            return Ok(basket);
        //        }
        //        else//иначе добавляем запись с этим продуктом
        //        {
        //            basket.Productid = productId;
        //            basket.Productname = _context.Products.First(x => x.Id == productId).Name;
        //            basket.Userid = userId;
        //            basket.Count = count;
        //            basket.Price = _context.Products.First(x => x.Id == productId).Price;
        //            _context.Baskets.Add(basket);
        //            _context.SaveChanges();
        //            return Ok(basket);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}
    }
}