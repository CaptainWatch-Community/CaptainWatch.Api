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

        Task ImportAllSeries();
        Task AddOrUpdateSerie(SearchSerieAddOrUpdateBo serie);
        Task DeleteSerie(int serieId);
        Task DeleteAllSeries();
    }
}
