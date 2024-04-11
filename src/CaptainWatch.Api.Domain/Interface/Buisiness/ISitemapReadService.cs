using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISitemapReadService
    {
        Task<IEnumerable<MovieSitemapBo>> GetMovies();
        Task<IEnumerable<SerieSitemapBo>> GetSeries();
        Task<IEnumerable<ListSitemapBo>> GetLists();
    }
}
