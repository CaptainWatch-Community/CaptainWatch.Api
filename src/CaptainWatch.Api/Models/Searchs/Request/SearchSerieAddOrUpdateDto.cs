using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchSerieAddOrUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? FirstAirDate { get; set; }
		public double? SiteScore { get; set; }
	}

    public static class SearchSerieAddOrUpdateExtensions
    {
        public static SearchSerieAddOrUpdateBo ToBo(this SearchSerieAddOrUpdateDto serie)
        {
            return new SearchSerieAddOrUpdateBo
            {
                Title = serie.Title,
                OriginalTitle = serie.OriginalTitle,
                FirstAirDate = serie.FirstAirDate,
				SiteScore = serie.SiteScore
			};
        }
    }
}
