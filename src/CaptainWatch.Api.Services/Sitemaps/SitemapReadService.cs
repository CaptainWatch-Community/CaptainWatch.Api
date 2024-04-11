using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Sitemaps
{
    public class SitemapReadService : ISitemapReadService
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;
        private readonly ISerieRepo _serieRepo;
        private readonly IListRepo _listRepo;

        public SitemapReadService(IMovieRepo movieRepo, ISerieRepo serieRepo, IListRepo listRepo)
        {
            _movieRepo = movieRepo;
            _serieRepo = serieRepo;
            _listRepo = listRepo;
        }

        #endregion

        public async Task<IEnumerable<SitemapMovieBo>> GetMovies()
        {
            var movies = await _movieRepo.GetMoviesWithPositiveSiteScore();

            var result = movies.Select(movie => new SitemapMovieBo
            {
                Title = movie.Title,
                Id = movie.Id
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<SitemapSerieBo>> GetSeries()
        {
            var series = await _serieRepo.GetSeriesWithPositiveSiteScore();

            var result = series.Select(serie => new SitemapSerieBo
            {
                Title = serie.Title,
                Id = serie.Id
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<SitemapListBo>> GetLists()
        {
            var lists = await _listRepo.GetLists();

            var result = lists.Select(list => new SitemapListBo
            {
                Id = list.Id,
                Name = list.Name
            }).ToList();

            return result;
        }

    }
}
