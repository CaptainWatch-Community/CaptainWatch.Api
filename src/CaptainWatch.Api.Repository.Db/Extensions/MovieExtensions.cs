using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using System.Linq.Expressions;

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

        public static IEnumerable<SearchMovieAddOrUpdateBo> ToSearchMovieAddOrUpdateBo(this IEnumerable<Movie> s)
        {
            return s.Select(_ => _.ToSearchMovieAddOrUpdateBo());
        }

        public static SearchMovieAddOrUpdateBo ToSearchMovieAddOrUpdateBo(this Movie s)
        {
            return new SearchMovieAddOrUpdateBo
            {
                Id = s.Id,
                Title = s.Title,
                OriginalTitle = s.OriginalTitle,
                MinReleaseDate = s.MinReleaseDate
            };
        }

        public static Expression<Func<Movie, SearchMovieAddOrUpdateBo>> ProjectionToSearchMovieAddOrUpdateBo => movie => new SearchMovieAddOrUpdateBo
        {
            Id = movie.Id,
            Title = movie.Title,
            OriginalTitle = movie.OriginalTitle,
            MinReleaseDate = movie.MinReleaseDate,
			SiteScore = movie.SiteScore
        };
    }
}
