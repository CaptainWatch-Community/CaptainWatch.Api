using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using System.ComponentModel.DataAnnotations;

namespace CaptainWatch.Api.Models.Searchs.Detail
{
    public class SearchSerieDto
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? FirstAirDate { get; set; }

        [Required]
        public double RankingScore { get; set; }

    }

    public static class SearchSerieExtensions
    {
        public static SearchSerieBo ToBo(this SearchSerieDto serie)
        {
            return new SearchSerieBo
            {
                Id = serie.Id,
                Title = serie.Title,
                OriginalTitle = serie.OriginalTitle,
                FirstAirDate = serie.FirstAirDate,
                RankingScore = serie.RankingScore
            };
        }
    }
}
