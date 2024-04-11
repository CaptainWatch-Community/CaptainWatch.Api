using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;

namespace CaptainWatch.Api.Models.Sitemaps.Detail
{
    public class SitemapListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    #region Extensions
    public static class SitemapListExtensions
    {
        public static SitemapListDto ToDto(this SitemapListBo list)
        {
            return new SitemapListDto
            {
                Id = list.Id,
                Name = list.Name
            };
        }

        public static IEnumerable<SitemapListDto> ToDto(this IEnumerable<SitemapListBo> lists)
        {
            return lists.Select(list => list.ToDto());
        }
    }
    #endregion
}
