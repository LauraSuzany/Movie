using Movie.Models;

namespace Movie.Repository
{
    public interface IMoviesRepository
    {
        List<MovieModel> FindAllMovies();
        MovieModel FindById(int id);
        MovieModel FindByName(string name);
        MovieModel AddMovie(MovieModel movie);
        MovieModel Update(MovieModel movie, int id);

        MovieModel Delete(int id);
    }
}
