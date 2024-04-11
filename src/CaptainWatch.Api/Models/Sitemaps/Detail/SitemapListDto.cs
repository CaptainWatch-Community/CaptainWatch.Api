using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

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
        public static SitemapListDto ToDto(this ListSitemapBo list)
        {
            return new SitemapListDto
            {
                Id = list.Id,
                Name = list.Name
            };
        }

        public static IEnumerable<SitemapListDto> ToDto(this IEnumerable<ListSitemapBo> lists)
        {
            return lists.Select(list => list.ToDto());
        }
    }
    #endregion
}
