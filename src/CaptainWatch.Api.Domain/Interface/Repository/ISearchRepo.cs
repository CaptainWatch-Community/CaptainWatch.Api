﻿using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface ISearchRepo
    {
        Task InitSearchEngine();
        Task AddMoviesDocuments(IEnumerable<SearchMovieAddOrUpdateBo> movies);
        Task DeleteMovieDocument(int movieId);
        Task AddOrUpdateMovieDocument(SearchMovieAddOrUpdateBo movie);
        Task DeleteAllMoviesDocuments();
        Task<IEnumerable<SearchMovieBo>> SearchMovies(SearchMovieQueryBo query);
    }
}
