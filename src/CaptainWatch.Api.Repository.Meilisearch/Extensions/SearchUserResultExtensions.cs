using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using CaptainWatch.Api.Repository.Meilisearch.Objects;

namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
    public static class SearchUserResultExtensions
    {

        public static IEnumerable<SearchUserBo> ToBo(this IEnumerable<SearchUserResult> s)
        {
            return s.Select(_ => _.ToBo());
        }

        public static SearchUserBo ToBo(this SearchUserResult s)
        {
            return new SearchUserBo
            {
                Id = s.Id,
                FullName = s.FullName,
                UserName = s.UserName,
                RankingScore = s._rankingScore
            };
        }
    }
}
