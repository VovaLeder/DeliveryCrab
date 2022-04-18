﻿using Microsoft.AspNetCore.Mvc;
using DeliveryCrab.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCrab.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetUser")]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }
        [HttpGet]
        [Route("GetUser/{id}")]
        public User Get(int id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        [Route("GetUser")]
        public IActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("GetUser")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.First(x => x.Id == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return Ok(id);
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
    }
}
