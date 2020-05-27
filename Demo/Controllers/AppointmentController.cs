using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private IUserProductService service;

        public AppointmentController(IUserProductService _service)
        {
            service = _service;
        }

        // GET: api/Users
        [HttpGet]
        public  ActionResult<IEnumerable<Appointment>> GetUsers()
        {
            return  service.GetAll().ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public  ActionResult<Appointment> GetUser(int id)
        {
            var userProduct =  service.Get(id);

            if (userProduct == null)
            {
                return NotFound();
            }

            return userProduct;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, Appointment userProduct)
        {
            if (id != userProduct.Id)
            {
                return BadRequest();
            }
            service.Update(userProduct);
         

            try
            {
                service.SaveChanges();
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
        public  ActionResult<Appointment> PostUser(Appointment user)
        {
            service.Add(user);
            service.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public  ActionResult<Appointment> DeleteUser(int id)
        {
            var userProduct =  service.Get(id);
            if (userProduct == null)
            {
                return NotFound();
            }

            service.Delete(userProduct);
            service.SaveChanges();

            return userProduct;
        }

        private bool UserExists(int id)
        {
            return service.GetAll().Any(e => e.Id == id);
        }
    }
}
