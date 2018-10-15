using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MovieQuotes.Data.Models;
using MovieQuotes.Services;

namespace MovieQuotes.Controllers
{
    [Authorize] 
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
         this.userService=userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userData)
        {
            var user = userService.Authenticate(userData.Username,userData.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]User userData)
        {
            var user = userService.Register(userData.Username,userData.Password);

            if (user == null)
                return BadRequest(new { message = "Username exist" });

            return Ok(user);
        }

       
    }
}