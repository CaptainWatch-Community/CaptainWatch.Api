using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISitemapReadService
    {
        Task<IEnumerable<SitemapMovieBo>> GetMovies();
        Task<IEnumerable<SitemapSerieBo>> GetSeries();
        Task<IEnumerable<SitemapListBo>> GetLists();
    }
}
