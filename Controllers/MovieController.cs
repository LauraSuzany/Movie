﻿using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.Repository;

namespace Movie.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MovieController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [HttpPost("Create")]
        public OkObjectResult Create([FromBody] MovieModel movie)
        {
            MovieModel movieModel = _moviesRepository.AddMovie(movie);
            return Ok(movie);
        }

        [HttpGet("Search/{nome}")]
        public OkObjectResult FindByName([FromRoute] string nome)
        {
            object movieModels = _moviesRepository.FindByName(nome);
            return Ok(movieModels);
        }

        [HttpGet("Find/{id}")]
        public OkObjectResult GetMovieById([FromRoute] int id)
        {
            object movieModels = _moviesRepository.FindById(id);
            return Ok(movieModels);
        }

    }
}
