using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using System.ComponentModel.DataAnnotations;

namespace CaptainWatch.Api.Models.Searchs.Detail
{
    public class SearchMovieDto
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? MinReleaseDate { get; set; }
        public double RankingScore { get; set; }

    }

    public static class SearchMovieExtensions
    {
        public static SearchMovieBo ToBo(this SearchMovieDto movie)
        {
            return new SearchMovieBo
            {
                Id = movie.Id,
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle,
                MinReleaseDate = movie.MinReleaseDate,
                RankingScore = movie.RankingScore
            };
        }
    }
}
