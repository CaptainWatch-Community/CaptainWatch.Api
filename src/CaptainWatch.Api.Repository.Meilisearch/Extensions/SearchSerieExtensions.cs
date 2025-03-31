using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchSerieExtensions
    {
        public static IEnumerable<SearchSerie> ToEntity(this IEnumerable<SearchSerieAddOrUpdateBo> s)
        {
            return s.Select(_ => _.ToEntity());
        }

        public static SearchSerie ToEntity(this SearchSerieAddOrUpdateBo s)
        {
            return new SearchSerie
            {
                Id = s.Id,
                Title = s.Title,
                OriginalTitle = s.OriginalTitle,
                FirstAirDate = s.FirstAirDate,
				SiteScore = s.SiteScore
			};
        }
    }
}
