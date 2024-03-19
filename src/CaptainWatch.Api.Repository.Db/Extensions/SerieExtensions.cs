using CaptainWatch.Api.Domain.Bo.Series.Result;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;

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
    }
}
