using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchListQueryDto
    {
        public string Query { get; set; } = string.Empty;
        public int[] ExcludedIds { get; set; } = Array.Empty<int>();
        public int MaxResults { get; set; } = 20;
    }

    public static class SearchListQueryExtensions
    {
        public static SearchListQueryBo ToBo(this SearchListQueryDto query)
        {
            return new SearchListQueryBo
            {
                Query = query.Query,
                ExcludedIds = query.ExcludedIds,
                MaxResults = query.MaxResults
            };
        }
    }
}
