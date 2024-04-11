using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;

namespace CaptainWatch.Api.Repository.Db.Extensions
{
    public static class MovieExtensions
    {
        public static IEnumerable<MoviePocBo> ToBoPoc(this IEnumerable<Movie> s)
        {
            return s.Select(_ => _.ToBoPoc());
        }

        public static MoviePocBo ToBoPoc(this Movie s)
        {
            return new MoviePocBo
            {
                Id = s.Id,
                Title = s.Title
            };
        }

        public static IEnumerable<MovieBo> ToBo(this IEnumerable<Movie> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static MovieBo ToBo(this Movie s)
        {
            return new MovieBo
            {
                Id = s.Id,
                Title = s.Title,
            };
        }
    }
}
