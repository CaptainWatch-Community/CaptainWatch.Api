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

        public async Task<IEnumerable<SearchSerieBo>> SearchSeries(SearchSerieQueryBo query)
        {
            var series = await _searchRepo.SearchSeries(query);
            return series;
        }

        public async Task<IEnumerable<SearchUserBo>> SearchUsers(SearchUserQueryBo query)
        {
            var users = await _searchRepo.SearchUsers(query);
            return users;
        }

        public async Task<IEnumerable<SearchPersonBo>> SearchPersons(SearchPersonQueryBo query)
        {
            var persons = await _searchRepo.SearchPersons(query);
            return persons;
        }

        public async Task<IEnumerable<SearchListBo>> SearchLists(SearchListQueryBo query)
        {
            var lists = await _searchRepo.SearchLists(query);
            return lists;
        }
    }
}
