using Microsoft.Extensions.WebEncoders.Testing;
using Movie.Context;
using Movie.Entity;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
        //public MovieEntity Delete(int id)
        //{
        //    _contexto.Movie.Remove(FindById(id));
        //    _contexto.SaveChanges();
        //    return null;
        //    throw new NotImplementedException();

        //}

        //public List<MovieEntity> FindAllMovies()
        //{
        //    throw new NotImplementedException();
        //}

        //public MovieEntity FindById(int id)
        //{
        //    return _contexto.Movie.FirstOrDefault(x => x.id == id);
        //    throw new NotImplementedException();
        //}

        //public object FindByName(string name)
        //{
        //    Microsoft.EntityFrameworkCore.DbSet<MovieEntity> movie = _contexto.Movie;
        //    IQueryable<MovieEntity> movieModels = movie.Where(x => x.Nome.Contains(name));
        //    return movieModels;
        //}

        public bool ExistName(string name)
        {
            Microsoft.EntityFrameworkCore.DbSet<MovieEntity> movie = _contexto.Movie;
            bool IsNamePresent = movie.Select(x => x.Nome.Equals(name)).FirstOrDefault();
            return IsNamePresent;
        }

        //public MovieEntity Update(MovieEntity movie)
        //{
        //    _contexto.Movie.Update(movie);
        //    _contexto.SaveChanges();
        //    return (movie);

        //    throw new NotImplementedException();
        //}
    }
}
