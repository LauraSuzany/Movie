using Movie.Entity;

namespace Movie.Repository
{
    public interface IMoviesRepository
    {
        //List<MovieEntity> FindAllMovies();
        //MovieEntity FindById(int id);
        //object FindByName(string name);
        public bool ExistName(string name);
        public object Add(MovieEntity movie);
        //MovieEntity Update(MovieEntity movie);

        //MovieEntity Delete(int id);
    }
}
