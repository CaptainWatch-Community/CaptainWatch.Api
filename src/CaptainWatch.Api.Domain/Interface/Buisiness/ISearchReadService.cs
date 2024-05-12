﻿using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISearchReadService
    {
        Task<IEnumerable<SearchMovieBo>> SearchMovies(SearchMovieQueryBo query);
    }
}
