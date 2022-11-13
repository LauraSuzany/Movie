﻿using Microsoft.AspNetCore.Http;
using Movie.Entity;
using Movie.Repository;
using Movie.Response;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace Movie.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MovieService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public object AddMovie(MovieModel movieModel)
        {
            if (_moviesRepository.ExistName(movieModel.Nome))
            {
                return $"O titulo {movieModel.Nome} já existe!";
            }

            MovieEntity movieEntity = new MovieEntity() {
                Nome = movieModel.Nome,
                DataLancamento = DateTime.Parse(DateTime.Parse(movieModel.DataLancamento).ToString("dd/MM/yyyy")),
                Categoria = movieModel.Categoria,
                Classificacao = movieModel.Classificacao,
                Descricao = movieModel.Descricao
            };
             _moviesRepository.Add(movieEntity);
            MovieResponse movieResponse = MovieResponse.Map(movieEntity);
            return movieResponse;
        }

        public object FindByID(int id)
        {
            MovieEntity movieEntity = _moviesRepository.FindById(id);
            if (movieEntity == null)
            {
                return $"O ID {id} não existe!";
            }
            
            MovieResponse movieResponse = MovieResponse.Map(movieEntity);
            return movieResponse;
        }

        public object FindByName(string name)
        {
            IQueryable<MovieEntity> movieEntities = _moviesRepository.FindByName(name);
            if (movieEntities.Count() == 0)
            {
                return $"O titulo {name} não existe!";
            }
            return movieEntities;
        }

        public object UpdateMovie(int id, MovieModel movieModel)
        {
            MovieEntity findById = _moviesRepository.FindById(id);
            if (findById == null)
            {
                return $"O id {id} não existe!";
            }
            
            MovieEntity movieEntityUpdate = new MovieEntity()
            {   id = id,
                Nome = movieModel.Nome,
                DataLancamento = DateTime.Parse(DateTime.Parse(movieModel.DataLancamento).ToString("dd/MM/yyyy")),
                Categoria = movieModel.Categoria,
                Classificacao = movieModel.Classificacao,
                Descricao = movieModel.Descricao
            };

            MovieEntity updatebyId = _moviesRepository.UpdateById(movieEntityUpdate);
            MovieResponse movieResponse = MovieResponse.Map(updatebyId);
            return movieResponse;
        }

        public string DeleteMovie(int id)
        {
            MovieEntity findById = _moviesRepository.FindById(id);
            if (findById == null)
            {
                return $"O id {id} não existe!";
            }
            _moviesRepository.DeleteByID(id);
            return $"O filme foi deletado com sucesso!";
        }
    }
}
