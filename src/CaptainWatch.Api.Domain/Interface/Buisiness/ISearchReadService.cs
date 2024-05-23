using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISearchReadService
    {
        Task<IEnumerable<SearchMovieBo>> SearchMovies(SearchMovieQueryBo query);
        Task<IEnumerable<SearchSerieBo>> SearchSeries(SearchSerieQueryBo query);
        Task<IEnumerable<SearchUserBo>> SearchUsers(SearchUserQueryBo query);
        Task<IEnumerable<SearchPersonBo>> SearchPersons(SearchPersonQueryBo query);
        Task<IEnumerable<SearchListBo>> SearchLists(SearchListQueryBo query);
    }
}
