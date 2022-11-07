using Movie.Entity;

namespace Movie.Service
{
    public interface IMovieService
    {
        public object AddMovie(MovieModel movieModel);
    }
}
