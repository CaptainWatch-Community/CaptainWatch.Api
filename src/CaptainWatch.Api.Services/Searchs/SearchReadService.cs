using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class SearchReadService : ISearchReadService
    {
        #region Declarations

        private readonly ISearchRepo _searchRepo;

        public SearchReadService(ISearchRepo searchRepo)
        {
            _searchRepo = searchRepo;
        }
        #endregion

        public async Task<IEnumerable<SearchMovieBo>> SearchMovies(SearchMovieQueryBo query)
        {
            var movies = await _searchRepo.SearchMovies(query);
            return movies;
        }
    }
}
