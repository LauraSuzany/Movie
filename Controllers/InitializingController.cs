using Microsoft.AspNetCore.Mvc;
using Movie.Context;

namespace Movie.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class InitializingController : ControllerBase
    {
        [HttpGet("Start")]
        public string Get()
        {
            return "Application started!";
        }
    }
}
