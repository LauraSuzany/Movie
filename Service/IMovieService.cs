﻿using Movie.Entity;
using Movie.Response;

namespace Movie.Service
{
    public interface IMovieService
    {
        public object AddMovie(MovieModel movieModel);
        public object FindByID(int id);
    }
}
