using Microsoft.AspNetCore.Http;
using Movie.Entity;
using Movie.Repository;
using System.Globalization;
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
            //if (_moviesRepository.ExistName(movieModel.Nome)) {

            //    return $"O titulo {movieModel.Nome} já existe!";

            //}
            
            MovieEntity movieEntity = new MovieEntity() { 
                Nome = movieModel.Nome,
                DataLancamento = Convert.ToDateTime(DateTime.Now.ToString("dd/MMM/yyyy") + " " + "10:15 PM")/*Add your time here*/;
            Categoria = movieModel.Categoria,
                Classificacao = movieModel.Classificacao,
                Descricao = movieModel.Descricao
            };
            DateTime DataLancamento;
            return _moviesRepository.Add(movieEntity);
        }
    }
}
