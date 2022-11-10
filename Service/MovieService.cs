using Microsoft.AspNetCore.Http;
using Movie.Entity;
using Movie.Repository;
using Movie.Response;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Dataflow;

namespace Movie.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MovieService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public object AddMovie(MovieModel movieModel)
        {
            if (_moviesRepository.ExistName(movieModel.Nome))
            {

                return $"O titulo {movieModel.Nome} já existe!";

            }

            MovieEntity movieEntity = new MovieEntity() {
                Nome = movieModel.Nome,
                DataLancamento = DateTime.Parse(DateTime.Parse(movieModel.DataLancamento).ToString("dd/MM/yyyy")),
                Categoria = movieModel.Categoria,
                Classificacao = movieModel.Classificacao,
                Descricao = movieModel.Descricao
            };
             _moviesRepository.Add(movieEntity);
            MovieResponse movieResponse = MovieResponse.Map(movieEntity);
            return movieResponse;
        }

        public object FindByID(int id)
        {
            MovieEntity movieEntity = _moviesRepository.FindById(id);
            if (movieEntity == null)
            {
                return $"O ID {id} não existe!";
            }
            
            MovieResponse movieResponse = MovieResponse.Map(movieEntity);
            return movieResponse;
        }
    }
}
