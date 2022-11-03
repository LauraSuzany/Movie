using Movie.Context;
using Movie.Models;

namespace Movie.Repository
{
    public class MoviesRepository : IMoviesRepository
    {

        private readonly Contexto _contexto;

        public MoviesRepository(Contexto context)
        {
            _contexto = context;
        }

        public MovieModel AddMovie(MovieModel movie)
        {
            _contexto.Add(movie);
            _contexto.SaveChanges();
            return movie;
        }

        public MovieModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieModel> FindAllMovies()
        {
            throw new NotImplementedException();
        }

        public MovieModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public MovieModel FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public MovieModel Update(MovieModel movie, int id)
        {
            throw new NotImplementedException();
        }
    }
}
