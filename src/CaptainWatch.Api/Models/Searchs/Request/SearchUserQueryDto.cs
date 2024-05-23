using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchUserQueryDto
    {
        public string Query { get; set; } = string.Empty;
        public int[] ExcludedIds { get; set; } = Array.Empty<int>();
        public int MaxResults { get; set; } = 20;
    }

    public static class SearchUserQueryExtensions
    {
        public static SearchUserQueryBo ToBo(this SearchUserQueryDto query)
        {
            return new SearchUserQueryBo
            {
                Query = query.Query,
                ExcludedIds = query.ExcludedIds,
                MaxResults = query.MaxResults
            };
        }
    }
}
