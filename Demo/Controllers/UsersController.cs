using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core;
using Entities;
using Service;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        // GET: api/Users
        [HttpGet]
        public  ActionResult<IEnumerable<User>> GetUsers()
        {
            return  userService.GetAll().ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public  ActionResult<User> GetUser(int id)
        {
            var user =  userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            userService.Update(user);
         

            try
            {
                userService.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public  ActionResult<User> PostUser(User user)
        {
            userService.Add(user);
            userService.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public  ActionResult<User> DeleteUser(int id)
        {
            var user =  userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            userService.Delete(user);
            userService.SaveChanges();

            return user;
        }

        private bool UserExists(int id)
        {
            return userService.GetAll().Any(e => e.Id == id);
        }
    }
}
