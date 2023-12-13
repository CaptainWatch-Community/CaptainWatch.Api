using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface ISitemapServiceRead
    {
        Task<IEnumerable<MovieSitemapBo>> GetMovieSitemapData();
    }
}
