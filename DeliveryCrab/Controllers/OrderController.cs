using Microsoft.AspNetCore.Mvc;
using DeliveryCrab.Models;

namespace DeliveryCrab.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {

        private readonly ApplicationContext _context;

        public OrderController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Order Get(int id)
        {
            Order? order = _context.Orders.FirstOrDefault(x => x.Id == id);
            return order;
        }

        [HttpGet]
        [Route("{UserId}")]
        public Order GetByUserId(int UserId)
        {
            Order? order = _context.Orders.FirstOrDefault(x => x.UserId == UserId);
            return order;
        }

        [HttpPost]
        [Route("AddAllByUserId")]
        public IActionResult AddAllByUserId(int userId, string addres)
        {
            if (ModelState.IsValid)
            {
                
                if (_context.Baskets.Any(x => x.UserId == userId))
                {
                    DateTime data = DateTime.Now;
                    Basket basket = new Basket();
                    basket = _context.Baskets.First(x => x.UserId == userId);

                    while (basket != null)
                    {
                        Order order = new Order();
                        order.Addres = addres;
                        order.UserId = userId;
                        order.ProductId = basket.ProductId;
                        order.Count = basket.Count;
                        order.Data = data;
                        order.Status = 0;

                        _context.Orders.Add(order);
                        _context.SaveChanges();

                        _context.Baskets.Remove(basket);
                        basket = new Basket();
                        basket = _context.Baskets.First(x => x.UserId == userId);
                    }
                    
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteAllByUserId")]
        public IActionResult DeleteAllByUserId(int userId)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order();
                order = _context.Orders.First(x => x.UserId == userId);
                if (order == null)
                {
                    return BadRequest(userId);
                }
                while (order != null)
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();

                    order = new Order();
                    order = _context.Orders.First(x => x.UserId == userId);
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }

    }
}
