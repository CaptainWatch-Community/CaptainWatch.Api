using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchMovieQueryDto
    {
        public string Query { get; set; } = string.Empty;
        public int[] ExcludedIds { get; set; } = Array.Empty<int>();
        public int MaxResults { get; set; } = 20;
    }

    public static class SearchMovieQueryExtensions
    {
        public static SearchMovieQueryBo ToBo(this SearchMovieQueryDto query)
        {
            return new SearchMovieQueryBo
            {
                Query = query.Query,
                ExcludedIds = query.ExcludedIds,
                MaxResults = query.MaxResults
            };
        }
    }
}
