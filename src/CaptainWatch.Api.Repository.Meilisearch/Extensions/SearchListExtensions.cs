using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchListExtensions
    {
        public static IEnumerable<SearchList> ToEntity(this IEnumerable<SearchListAddOrUpdateBo> s)
        {
            return s.Select(_ => _.ToEntity());
        }

        public static SearchList ToEntity(this SearchListAddOrUpdateBo s)
        {
            return new SearchList
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
