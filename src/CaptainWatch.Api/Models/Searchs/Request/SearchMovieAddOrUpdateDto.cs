using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchMovieAddOrUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? MinReleaseDate { get; set; }
    }

    public static class SearchMovieAddOrUpdateExtensions
    {
        public static SearchMovieAddOrUpdateBo ToBo(this SearchMovieAddOrUpdateDto movie)
        {
            return new SearchMovieAddOrUpdateBo
            {
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle,
                MinReleaseDate = movie.MinReleaseDate
            };
        }
    }
}
