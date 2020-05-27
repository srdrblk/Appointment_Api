using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;
using Helpers;

namespace Demo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private Authentication authentication ;
        public AuthenticationController(Authentication _authentication)
        {
            authentication = _authentication;
        
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginViewModel loginParam)
        {
            var user = authentication.Authenticate(loginParam.UserName, loginParam.Password);
            if (user == null)
                return BadRequest(new { message = "Kullanici veya şifre hatalı!" });
            return Ok(user);
        }
      
    }
}