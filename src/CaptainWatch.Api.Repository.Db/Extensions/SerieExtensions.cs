using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Bo.Series.Detail;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using System.Linq.Expressions;

namespace CaptainWatch.Api.Repository.Db.Extensions
{
    public static class SerieExtensions
    {

        public static IEnumerable<SerieBo> ToBo(this IEnumerable<Tv> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static SerieBo ToBo(this Tv s)
        {
            return new SerieBo
            {
                Id = s.Id,
                Title = s.Name,
            };
        }

        public static Expression<Func<Tv, SearchSerieAddOrUpdateBo>> ProjectionToSearchSerieAddOrUpdateBo => serie => new SearchSerieAddOrUpdateBo
        {
            Id = serie.Id,
            Title = serie.Name,
            OriginalTitle = serie.OriginalName,
            FirstAirDate = serie.FirstAirDate
        };
    }
}
