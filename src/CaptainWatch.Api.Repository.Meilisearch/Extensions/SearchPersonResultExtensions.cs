using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchPersonResultExtensions
    {

        public static IEnumerable<SearchPersonBo> ToBo(this IEnumerable<SearchPersonResult> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static SearchPersonBo ToBo(this SearchPersonResult s)
        {
            return new SearchPersonBo
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
