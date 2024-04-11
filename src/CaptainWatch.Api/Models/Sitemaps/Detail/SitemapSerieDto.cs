using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;

namespace CaptainWatch.Api.Models.Sitemaps.Detail
{
    public class SitemapSerieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    #region Extensions
    public static class SitemapSerieExtensions
    {
        public static SitemapSerieDto ToDto(this SerieSitemapBo serie)
        {
            return new SitemapSerieDto
            {
                Id = serie.Id,
                Title = serie.Title
            };
        }

        public static IEnumerable<SitemapSerieDto> ToDto(this IEnumerable<SerieSitemapBo> series)
        {
            return series.Select(serie => serie.ToDto());
        }
    }
    #endregion
}
