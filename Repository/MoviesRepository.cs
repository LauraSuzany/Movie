using Microsoft.Extensions.WebEncoders.Testing;
using Movie.Context;
using Movie.Models;
using System.Text.RegularExpressions;

namespace Movie.Repository
{
    public class MoviesRepository : IMoviesRepository
    {

        private readonly Contexto _contexto;

        public MoviesRepository(Contexto context)
        {
            _contexto = context;
        }

        public MovieModel AddMovie(MovieModel movie)
        {
            _contexto.Add(movie);
            _contexto.SaveChanges();
            return movie;
        }

        public MovieModel Delete(int id)
        {
            _contexto.Movie.Remove(FindById(id));
            _contexto.SaveChanges();
            return null;
            throw new NotImplementedException();

        }

        public List<MovieModel> FindAllMovies()
        {
            throw new NotImplementedException();
        }

        public MovieModel FindById(int id)
        {
            return _contexto.Movie.FirstOrDefault(x => x.id == id);
            throw new NotImplementedException();
        }

        public object FindByName(string name)
        { 
            Microsoft.EntityFrameworkCore.DbSet<MovieModel> movie = _contexto.Movie;
            IQueryable<MovieModel> movieModels = movie.Where(x => x.Nome.Contains(name));

            if (movieModels.Count() <= 0)
            {
                object mensagemErro =  $"Nome {name} não encontrado";
                return mensagemErro;
            }
            return movieModels;
        }

        public MovieModel Update(MovieModel movie)
        {
            _contexto.Movie.Update(movie);
            _contexto.SaveChanges();
            return (movie);

            throw new NotImplementedException();
        }
    }
}
