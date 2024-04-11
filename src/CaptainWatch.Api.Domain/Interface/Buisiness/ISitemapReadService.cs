using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISitemapReadService
    {
        Task<IEnumerable<MovieSitemapBo>> GetMovieSitemapData();
        Task<IEnumerable<SerieSitemapBo>> GetSerieSitemapData();
        Task<IEnumerable<ListSitemapBo>> GetListSitemapData();
    }
}
