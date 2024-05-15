using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchPersonExtensions
    {
        public static IEnumerable<SearchPerson> ToEntity(this IEnumerable<SearchPersonAddOrUpdateBo> s)
        {
            return s.Select(_ => _.ToEntity());
        }

        public static SearchPerson ToEntity(this SearchPersonAddOrUpdateBo s)
        {
            return new SearchPerson
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
