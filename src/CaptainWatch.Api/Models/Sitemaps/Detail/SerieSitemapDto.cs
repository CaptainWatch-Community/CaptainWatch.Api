using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

namespace CaptainWatch.Api.Models.Sitemaps.Detail
{
    public class SerieSitemapDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public static class SerieSitemapExtensions
    {
        public static SerieSitemapDto ToDto(this SerieSitemapBo serie)
        {
            return new SerieSitemapDto
            {
                Id = serie.Id,
                Title = serie.Title
            };
        }

        public static IEnumerable<SerieSitemapDto> ToDto(this IEnumerable<SerieSitemapBo> series)
        {
            return series.Select(serie => serie.ToDto());
        }
    }
}
