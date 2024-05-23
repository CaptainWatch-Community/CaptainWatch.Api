using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchUserExtensions
    {
        public static IEnumerable<SearchUser> ToEntity(this IEnumerable<SearchUserAddOrUpdateBo> s)
        {
            return s.Select(_ => _.ToEntity());
        }

        public static SearchUser ToEntity(this SearchUserAddOrUpdateBo s)
        {
            return new SearchUser
            {
                Id = s.Id,
                FullName = s.FullName,
                Pseudo = s.Pseudo
            };
        }
    }
}
