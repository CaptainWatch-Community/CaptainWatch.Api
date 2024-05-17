using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchListResultExtensions
    {

        public static IEnumerable<SearchListBo> ToBo(this IEnumerable<SearchListResult> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static SearchListBo ToBo(this SearchListResult s)
        {
            return new SearchListBo
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
