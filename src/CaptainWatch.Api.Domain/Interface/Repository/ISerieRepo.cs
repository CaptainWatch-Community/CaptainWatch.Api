using CaptainWatch.Api.Domain.Bo.Series.Result;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface ISerieRepo
    {
        Task<IEnumerable<SerieBo>> GetSeriesWithPositiveSiteScore();
    }
}
