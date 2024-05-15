using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchSerieQueryDto
    {
        public string Query { get; set; } = string.Empty;
        public int[] ExcludedIds { get; set; } = Array.Empty<int>();
        public int MaxResults { get; set; } = 20;
    }

    public static class SearchSerieQueryExtensions
    {
        public static SearchSerieQueryBo ToBo(this SearchSerieQueryDto query)
        {
            return new SearchSerieQueryBo
            {
                Query = query.Query,
                ExcludedIds = query.ExcludedIds,
                MaxResults = query.MaxResults
            };
        }
    }
}
