using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MovieQuotes.Data.Models;

namespace MovieQuotes.Controllers
{
    [Authorize] 
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
       

        public UsersController()
        {
         
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = new {};

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]User userParam)
        {
            var user = new{};

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

       
    }
}