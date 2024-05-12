using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISearchWriteService
    {
        Task InitSearchEngine();
        Task ImportAllMovies();
        Task AddOrUpdateMovie(SearchMovieAddOrUpdateBo movie);
        Task DeleteMovie(int movieId);
        Task DeleteAllMovies();
    }
}
