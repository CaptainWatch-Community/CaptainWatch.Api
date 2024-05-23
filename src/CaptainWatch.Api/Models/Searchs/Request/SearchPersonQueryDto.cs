using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchPersonQueryDto
    {
        public string Query { get; set; } = string.Empty;
        public int[] ExcludedIds { get; set; } = Array.Empty<int>();
        public int MaxResults { get; set; } = 20;
    }

    public static class SearchPersonQueryExtensions
    {
        public static SearchPersonQueryBo ToBo(this SearchPersonQueryDto query)
        {
            return new SearchPersonQueryBo
            {
                Query = query.Query,
                ExcludedIds = query.ExcludedIds,
                MaxResults = query.MaxResults
            };
        }
    }
}
