using Movie.Entity;
using Movie.Response;

namespace Movie.Service
{
    public interface IMovieService
    {
        public object AddMovie(MovieModel movieModel);

        public List<MovieEntity> GetMovies();

        public object FindByID(int id);

        public object FindByName(string name);

        public object UpdateMovie(int id, MovieModel movieModel);

        public string DeleteMovie(int id);
    }
}
