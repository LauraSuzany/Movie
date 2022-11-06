using Movie.Entity;

namespace Movie.Repository
{
    public interface IMoviesRepository
    {
        //List<MovieEntity> FindAllMovies();
        //MovieEntity FindById(int id);
        //object FindByName(string name);
        public void Add(MovieEntity movie);
        //MovieEntity Update(MovieEntity movie);

        //MovieEntity Delete(int id);
    }
}
