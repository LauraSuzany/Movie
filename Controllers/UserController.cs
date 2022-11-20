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

        [HttpGet("ListUsers")]
        public object GetAllUsers()
        {
            object response = _userService.GetUsers();
            return Ok(new { Data = response });
        }

        [HttpGet("Find/{id}")]
        public object GetUserById([FromRoute] int id)
        {
            object response = _userService.FindByID(id);
            return Ok(new { Data = response });
        }

        [HttpGet("FindNickname/{nickname}")]
        public object GetUserById([FromRoute] string nickname)
        {
            object response = _userService.FindByFindByNickname(nickname);
            return Ok(new { Data = response });
        }

        [HttpPatch("UpdateUser/{id}")]
        public object GetUserById([FromRoute] long id, [FromBody] UserModel userModel)
        {
            object response = _userService.UpdateUser(id, userModel);
            return Ok(new { Data = response });
        }

        [HttpDelete("DeleteUser/{id}")]
        public object GetUserById([FromRoute] long id)
        {
            object response = _userService.DeleteUser(id);
            return Ok(new { Data = response });
        }
    }
}
