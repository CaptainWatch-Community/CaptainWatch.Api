using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;

namespace CaptainWatch.Api.Models.Sitemaps.Detail
{
    public class SitemapMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    #region Extensions
    public static class SitemapMovieExtensions
    {
        public static SitemapMovieDto ToDto(this MovieSitemapBo movie)
        {
            return new SitemapMovieDto
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }

        public static IEnumerable<SitemapMovieDto> ToDto(this IEnumerable<MovieSitemapBo> movies)
        {
            return movies.Select(movie => movie.ToDto());
        }
    }
    #endregion
}
