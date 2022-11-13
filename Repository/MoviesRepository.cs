using Microsoft.EntityFrameworkCore;
using Movie.Context;
using Movie.Entity;

namespace Movie.Repository
{
    public class MoviesRepository : IMoviesRepository
    {

        private readonly Contexto _contexto;

        public MoviesRepository(Contexto context)
        {
            _contexto = context;
        }

        /// <summary>
        /// add a new movie
        /// </summary>
        /// <param name="movie"> object movie </param>
        /// <returns> return the movie registered </returns>
        public object Add(MovieEntity movie)
        {
            _contexto.Add(movie);
            _contexto.SaveChanges();
            return movie;
        }
        
        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns>all movies</returns>
        public List<MovieEntity> GetAllMovies()
        {
            try
            {
                List<MovieEntity> movieEntities = _contexto.Movie.ToList();
                return movieEntities;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }
        }

        /// <summary>
        /// Search for a movie ID
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns>The object of the movie</returns>
        public MovieEntity FindById(int id)
        {
            try
            {
                /*.AsNoTracking() foi usado pois está dando um exceção de contexto, pois em alguns métodos são usados mais de um contexto
                 * de requisição ao banco ex: UpdateMovie() usa findByid (que abre um contexto e isto é rastreado) e UpdateById que abre 
                 * outro contexto que também é rastreado, logo, como a injeção de dependência é uma singleton os contextos abertos geram 
                 * conflito logo o método AsNoTracking() não rastreia esse contexto porém ele pode ser usado apenas para requisições que não 
                 * fazem alteração no banco
                 */

                MovieEntity? movieEntity = _contexto.Movie.AsNoTracking().FirstOrDefault(x => x.id == id);
                return movieEntity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool FindByName(string name)
        {
            Microsoft.EntityFrameworkCore.DbSet<MovieEntity> movie = _contexto.Movie;
            bool IsNamePresent = movie.Where(x => x.Nome.Equals(name)).Select(x => x.Nome.Equals(name)).FirstOrDefault();
            return IsNamePresent;
        }

        /// <summary>
        /// Get the movies that contain the name
        /// </summary>
        /// <param name="name"> name you want to find</param>
        /// <returns>All movies that contain that name you passed</returns>
        public IQueryable<MovieEntity> NameExist(string name)
        {
            try
            {
                Microsoft.EntityFrameworkCore.DbSet<MovieEntity> movie = _contexto.Movie;
                IQueryable<MovieEntity> movieModels = movie.Where(x => x.Nome.Contains(name));
                return movieModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns>The object that was updated</returns>
        public MovieEntity UpdateById(MovieEntity movie)
        {
            try
            {
                _contexto.Movie.Update(movie);
                _contexto.SaveChanges();
                return (movie);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }

        }

        /// <summary>
        /// Delete movie by ID
        /// </summary>
        /// <param name="id">Id movie</param>
        /// <returns></returns>
        public void DeleteByID(int id)
        {
            try
            {
                _contexto.Movie.Remove(FindById(id));
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Dispose();
            }

        }
    }
}
