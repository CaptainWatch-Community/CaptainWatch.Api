using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface IListRepo
    {
        Task<IEnumerable<ListSitemapBo>> GetLists();
    }
}
