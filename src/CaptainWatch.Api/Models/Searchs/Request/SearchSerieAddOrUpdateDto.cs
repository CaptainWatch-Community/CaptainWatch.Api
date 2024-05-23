using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchSerieAddOrUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? FirstAirDate { get; set; }
    }

    public static class SearchSerieAddOrUpdateExtensions
    {
        public static SearchSerieAddOrUpdateBo ToBo(this SearchSerieAddOrUpdateDto movie)
        {
            return new SearchSerieAddOrUpdateBo
            {
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle,
                FirstAirDate = movie.FirstAirDate
            };
        }
    }
}
