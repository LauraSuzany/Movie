using Microsoft.AspNetCore.Mvc;
using Movie.Entity;
using Movie.Service;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;



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
            return Ok(new{ response = response });
        }

        //[HttpGet("Search/{nome}")]
        //public OkObjectResult FindByName([FromRoute] string nome)
        //{
        //    object movieModels = _moviesRepository.FindByName(nome);
        //    return Ok(movieModels);
        //}

        //[HttpGet("Find/{id}")]
        //public object GetMovieById([FromRoute] int id)
        //{
        //    object movieModels = _moviesRepository.FindById(id);
        //    return Ok(movieModels);
        //}

        //[HttpDelete("Delete/{id}")]
        //public bool DeleteById([FromRoute] int id)
        //{
        //    object movieModels = _moviesRepository.Delete(id);
        //    return true;
        //}

        //[HttpPatch("Update")]
        //public MovieEntity Update([FromBody] MovieEntity movie)
        //{
        //    _moviesRepository.Update(movie);
        //    return movie;
        //}

    }
}
