using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISitemapReadService
    {
        Task<IEnumerable<MovieSitemapBo>> GetMovies();
        Task<IEnumerable<SerieSitemapBo>> GetSeries();
        Task<IEnumerable<ListSitemapBo>> GetLists();
    }
}
