using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Sitemaps
{
    public class SitemapServiceRead : ISitemapServiceRead
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;
        private readonly ISerieRepo _serieRepo;
        private readonly IListRepo _listRepo;

        public SitemapServiceRead(IMovieRepo movieRepo, ISerieRepo serieRepo, IListRepo listRepo)
        {
            _movieRepo = movieRepo;
            _serieRepo = serieRepo;
            _listRepo = listRepo;
        }

        #endregion

        public async Task<IEnumerable<MovieSitemapBo>> GetMovieSitemapData()
        {
            var movies = await _movieRepo.GetMoviesWithPositiveSiteScore();

            var result = movies.Select(movie => new MovieSitemapBo
            {
                Title = movie.Title,
                Id = movie.Id
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<SerieSitemapBo>> GetSerieSitemapData()
        {
            var series = await _serieRepo.GetSeriesWithPositiveSiteScore();

            var result = series.Select(serie => new SerieSitemapBo
            {
                Title = serie.Title,
                Id = serie.Id
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<ListSitemapBo>> GetListSitemapData()
        {
            var lists = await _listRepo.GetLists();

            var result = lists.Select(list => new ListSitemapBo
            {
                Id = list.Id,
                Name = list.Name
            }).ToList();

            return result;
        }

    }
}
