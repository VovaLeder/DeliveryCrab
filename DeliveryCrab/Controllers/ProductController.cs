using Microsoft.AspNetCore.Mvc;
using DeliveryCrab.Models;
namespace DeliveryCrab.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public Product Get(int id)
        {
            Product? product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        [HttpPost]
        [Route("PostProduct")]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Product product = _context.Products.First(x => x.Id == id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return Ok(id);
                }
                return BadRequest(); // Честно хз, что отправлять, если пытаться удалить юзера, id которого нет, так что пока так
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("PutProduct")]
        public IActionResult Put(Product product)
        {
            if (ModelState.IsValid)
            {
                Product old_product = _context.Products.First(x => x.Id == product.Id);
                old_product.Id = product.Id;
                old_product.Name = product.Name;
                old_product.Icon = product.Icon;
                old_product.Price = product.Price;
                old_product.Description = product.Description;
                old_product.RestaurantId = product.RestaurantId;

                _context.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }
    }
}
