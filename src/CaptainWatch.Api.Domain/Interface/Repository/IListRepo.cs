using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface IListRepo
    {
        Task<IEnumerable<ListSitemapBo>> GetLists();
    }
}
