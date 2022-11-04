using Movie.Models;

namespace Movie.Repository
{
    public interface IMoviesRepository
    {
        List<MovieModel> FindAllMovies();
        MovieModel FindById(int id);
        object FindByName(string name);
        MovieModel AddMovie(MovieModel movie);
        MovieModel Update(MovieModel movie);

        MovieModel Delete(int id);
    }
}
