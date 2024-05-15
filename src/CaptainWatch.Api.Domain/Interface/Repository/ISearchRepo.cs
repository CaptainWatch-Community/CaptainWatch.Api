using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
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

        Task AddSeriesDocuments(IEnumerable<SearchSerieAddOrUpdateBo> series);
        Task DeleteSerieDocument(int serieId);
        Task AddOrUpdateSerieDocument(SearchSerieAddOrUpdateBo serie);
        Task DeleteAllSeriesDocuments();
        Task<IEnumerable<SearchSerieBo>> SearchSeries(SearchSerieQueryBo query);

        Task AddUsersDocuments(IEnumerable<SearchUserAddOrUpdateBo> users);
        Task DeleteUserDocument(int userId);
        Task AddOrUpdateUserDocument(SearchUserAddOrUpdateBo user);
        Task DeleteAllUsersDocuments();
        Task<IEnumerable<SearchUserBo>> SearchUsers(SearchUserQueryBo query);

        Task AddPersonsDocuments(IEnumerable<SearchPersonAddOrUpdateBo> persons);
        Task DeletePersonDocument(int personId);
        Task AddOrUpdatePersonDocument(SearchPersonAddOrUpdateBo person);
        Task DeleteAllPersonsDocuments();
        Task<IEnumerable<SearchPersonBo>> SearchPersons(SearchPersonQueryBo query);
    }
}
