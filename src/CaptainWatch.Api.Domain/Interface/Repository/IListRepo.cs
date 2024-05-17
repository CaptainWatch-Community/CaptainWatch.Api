using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface IListRepo
    {
        Task<IEnumerable<SitemapListBo>> GetLists();
        Task<IEnumerable<SearchListAddOrUpdateBo>> GetAllListsForSearch();

    }
}
