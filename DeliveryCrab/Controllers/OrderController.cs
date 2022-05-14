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
        [HttpPost]
        [Route("PostOrder")]
        public IActionResult Post(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return Ok(order);
                
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("PutOrder")]
        public IActionResult Put(Order order)
        {
            if (ModelState.IsValid)
            {
                Order old_order = _context.Orders.First(x => x.Id == order.Id);
                old_order.Status = order.Status;
                _context.SaveChanges();
                return Ok(order);
            }
            return BadRequest(ModelState);
        }
    }
}
