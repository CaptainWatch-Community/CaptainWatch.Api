using CaptainWatch.Api.Domain.Bo.Movies.Result;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;

namespace CaptainWatch.Api.Repository.Db.Extensions
{
    public static class MovieExtensions
    {
        public static IEnumerable<MoviePocBo> ToBo(this IEnumerable<Movie> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static MoviePocBo ToBo(this Movie s)
        {
            return new MoviePocBo
            {
                Id = s.Id,
                Title = s.Title
            };
        }
    }
}
