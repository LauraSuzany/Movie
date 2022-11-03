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
            throw new NotImplementedException();
        }

        public List<MovieModel> FindAllMovies()
        {
            throw new NotImplementedException();
        }

        public MovieModel FindById(int id)
        {
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

        public MovieModel Update(MovieModel movie, int id)
        {
            throw new NotImplementedException();
        }
    }
}
