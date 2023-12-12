using CaptainWatch.Api.Domain.Bo.Movies.Result;

namespace CaptainWatch.Api.Models.Movies.Detail
{
    public class MoviePocDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public static class MovieExtensions
    {
        public static MoviePocDto ToDto(this MoviePocBo movie)
        {
            return new MoviePocDto
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }

        public static IEnumerable<MoviePocDto> ToDto(this IEnumerable<MoviePocBo> movies)
        {
            return movies.Select(movie => movie.ToDto());
        }
    }
}
