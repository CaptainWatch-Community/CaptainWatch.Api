using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchSerieResultExtensions
    {

        public static IEnumerable<SearchSerieBo> ToBo(this IEnumerable<SearchSerieResult> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static SearchSerieBo ToBo(this SearchSerieResult s)
        {
            return new SearchSerieBo
            {
                Id = s.Id,
                Title = s.Title,
                OriginalTitle = s.OriginalTitle,
                FirstAirDate = s.FirstAirDate,
                RankingScore = s._rankingScore
            };
        }
    }
}
