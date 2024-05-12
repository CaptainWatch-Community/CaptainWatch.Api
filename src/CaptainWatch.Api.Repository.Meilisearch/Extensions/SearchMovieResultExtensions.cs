using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchMovieResultExtensions
    {

        public static IEnumerable<SearchMovieBo> ToBo(this IEnumerable<SearchMovieResult> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static SearchMovieBo ToBo(this SearchMovieResult s)
        {
            return new SearchMovieBo
            {
                Id = s.Id,
                Title = s.Title,
                OriginalTitle = s.OriginalTitle,
                MinReleaseDate = s.MinReleaseDate,
                RankingScore = s._rankingScore
            };
        }
    }
}
