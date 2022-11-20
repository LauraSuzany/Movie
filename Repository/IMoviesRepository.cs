using Movie.Entity;

namespace Movie.Repository
{
    public interface IMoviesRepository
    {
        public object Add(MovieEntity movie);

        public List<MovieEntity> GetAllMovies();

        MovieEntity FindById(long id);

        public bool FindByName(string name);

        public IQueryable<MovieEntity> NameExist(string name);

        public MovieEntity UpdateById(MovieEntity movie);

        public void DeleteByID(int id);
    }
}
