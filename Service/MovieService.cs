using Movie.Entity;
using Movie.Repository;

namespace Movie.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MovieService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public void AddMovie(MovieModel movieModel)
        {
            MovieEntity movieEntity = new MovieEntity() { 
                Nome = movieModel.Nome,
                DataLancamento = movieModel.DataLancamento,
                Categoria = movieModel.Categoria,
                Classificacao = movieModel.Classificacao,
                Descricao = movieModel.Descricao
            };
            _moviesRepository.Add(movieEntity);
        }
    }
}
