using Movie.Entity;

namespace Movie.Repository
{
    public interface IMoviesRepository
    {
        MovieEntity FindById(int id);
        public IQueryable<MovieEntity> FindByName(string name);
        public bool ExistName(string name);
        public object Add(MovieEntity movie);
        public List<MovieEntity> GetAllMovies();
        public MovieEntity UpdateById(MovieEntity movie);
        public void DeleteByID(int id);
    }
}
