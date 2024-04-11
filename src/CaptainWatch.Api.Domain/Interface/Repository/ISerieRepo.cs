using CaptainWatch.Api.Domain.Bo.Series.Detail;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface ISerieRepo
    {
        Task<IEnumerable<SerieBo>> GetSeriesWithPositiveSiteScore();
    }
}
