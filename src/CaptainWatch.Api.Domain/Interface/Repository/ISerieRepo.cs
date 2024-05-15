using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Bo.Series.Detail;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface ISerieRepo
    {
        Task<IEnumerable<SerieBo>> GetSeriesWithPositiveSiteScore();
        Task<IEnumerable<SearchSerieAddOrUpdateBo>> GetAllSeriesForSearch();

    }
}
