using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class SearchWriteService : ISearchWriteService
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;
        private readonly ISearchRepo _searchRepo;
        private readonly ISerieRepo _serieRepo;

        public SearchWriteService(IMovieRepo movieRepo, ISearchRepo searchRepo, ISerieRepo serieRepo)
        {
            _movieRepo = movieRepo;
            _searchRepo = searchRepo;
            _serieRepo = serieRepo;
        }
        #endregion

        public async Task InitSearchEngine()
        {
            await _searchRepo.InitSearchEngine();
        }

        #region Movies
        public async Task DeleteAllMovies()
        {
            await _searchRepo.DeleteAllMoviesDocuments();
        }

        public async Task DeleteMovie(int movieId)
        {
            await _searchRepo.DeleteMovieDocument(movieId);
        }

        public async Task ImportAllMovies()
        {
            var movies = await _movieRepo.GetAllMoviesForSearch();
            await _searchRepo.AddMoviesDocuments(movies);
        }

        public async Task AddOrUpdateMovie( SearchMovieAddOrUpdateBo movie)
        {
            await _searchRepo.AddOrUpdateMovieDocument(movie);
        }
        #endregion

        #region Series
        public async Task DeleteAllSeries()
        {
            await _searchRepo.DeleteAllSeriesDocuments();
        }

        public async Task DeleteSerie(int serieId)
        {
            await _searchRepo.DeleteSerieDocument(serieId);
        }

        public async Task ImportAllSeries()
        {
            var series = await _serieRepo.GetAllSeriesForSearch();
            await _searchRepo.AddSeriesDocuments(series);
        }

        public async Task AddOrUpdateSerie(SearchSerieAddOrUpdateBo serie)
        {
            await _searchRepo.AddOrUpdateSerieDocument(serie);
        }

        #endregion
    }
}
