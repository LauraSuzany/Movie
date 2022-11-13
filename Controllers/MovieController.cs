using Microsoft.AspNetCore.Mvc;
using Movie.Entity;
using Movie.Service;

namespace Movie.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] MovieModel movie)
        {
            object response = _movieService.AddMovie(movie);
            return Ok(new{ Data = response });
        }

        [HttpGet("GetMovies")]
        public IActionResult ListAllMovies()
        {
            object response = _movieService.GetMovies();
            return Ok(new { Data = response });
        }

        [HttpGet("Find/{id}")]
        public object GetMovieById([FromRoute] int id)
        {
            object response = _movieService.FindByID(id);
            return Ok(new { Data = response });
        }

        [HttpGet("Search/{nome}")]
        public OkObjectResult FindByName([FromRoute] string nome)
        {
            object movieModels = _movieService.FindByName(nome);
            return Ok(new { Data = movieModels });
        }

        [HttpPatch("Update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MovieModel movieModel)
        {
            object response = _movieService.UpdateMovie(id, movieModel);
            return Ok(new { Data = response });
        }

        [HttpDelete("Delete/{id}")]
        public ObjectResult DeleteById([FromRoute] int id)
        {
            string response = _movieService.DeleteMovie(id);
            return Ok(new { Data = response });
        }

    }
}
