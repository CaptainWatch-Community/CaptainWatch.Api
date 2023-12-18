using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Sitemaps
{
    public class SitemapServiceRead : ISitemapServiceRead
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;

        public SitemapServiceRead(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        #endregion

        public async Task<IEnumerable<MovieSitemapBo>> GetMovieSitemapData()
        {
            var movies = await _movieRepo.GetMoviesWithPositiveSiteScore();

            var result = movies.Select(movie => new MovieSitemapBo
            {
                Title = movie.Title ?? movie.OriginalTitle,
                Id = movie.Id
            }).ToList();

            return result;
        }

    }
}
