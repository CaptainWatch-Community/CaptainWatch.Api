using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

namespace CaptainWatch.Api.Models.Sitemaps.Detail
{
    public class MovieSitemapDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public static class MovieSitemapExtensions
    {
        public static MovieSitemapDto ToDto(this MovieSitemapBo movie)
        {
            return new MovieSitemapDto
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }

        public static IEnumerable<MovieSitemapDto> ToDto(this IEnumerable<MovieSitemapBo> movies)
        {
            return movies.Select(movie => movie.ToDto());
        }
    }
}
