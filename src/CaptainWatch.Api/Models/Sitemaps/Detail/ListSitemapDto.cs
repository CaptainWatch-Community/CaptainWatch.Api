using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

namespace CaptainWatch.Api.Models.Sitemaps.Detail
{
    public class ListSitemapDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public static class ListSitemapExtensions
    {
        public static ListSitemapDto ToDto(this ListSitemapBo list)
        {
            return new ListSitemapDto
            {
                Id = list.Id,
                Name = list.Name
            };
        }

        public static IEnumerable<ListSitemapDto> ToDto(this IEnumerable<ListSitemapBo> lists)
        {
            return lists.Select(list => list.ToDto());
        }
    }
}
