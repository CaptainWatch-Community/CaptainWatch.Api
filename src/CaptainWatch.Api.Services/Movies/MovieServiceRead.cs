﻿using CaptainWatch.Api.Domain.Bo.Movies.Result;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class MovieServiceRead : IMovieServiceRead
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;

        public MovieServiceRead(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        #endregion
        public async Task<IEnumerable<MoviePocBo>> GetMoviesPoc()
        {
            return await _movieRepo.GetMoviesPoc();
        }
    }
}
