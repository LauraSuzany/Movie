using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.Service;

namespace Movie.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserModel userModel)
        {
            object response = _userService.AddUser(userModel);
            return Ok(new { Data = response });
        }

        [HttpGet("Find/{id}")]
        public object GetUserById([FromRoute] int id)
        {
            object response = _userService.FindByID(id);
            return Ok(new { Data = response });
        }
    }
}
