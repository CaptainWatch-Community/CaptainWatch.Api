using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchMovieExtensions
    {
        public static IEnumerable<SearchMovie> ToEntity(this IEnumerable<SearchMovieAddOrUpdateBo> s)
        {
            return s.Select(_ => _.ToEntity());
        }

        public static SearchMovie ToEntity(this SearchMovieAddOrUpdateBo s)
        {
            return new SearchMovie
            {
                Id = s.Id,
                Title = s.Title,
                OriginalTitle = s.OriginalTitle,
                MinReleaseDate = s.MinReleaseDate
            };
        }
    }
}
