using CaptainWatch.Api.Domain.Bo.Movies.Result;
using CaptainWatch.Api.Domain.Interface.Buisiness;

namespace CaptainWatch.Api.Services.Movies
{
    public class MovieServiceRead : IMovieServiceRead
    {
        public async Task<IEnumerable<MoviePocBo>> GetMoviesPoc()
        {
            var result = new List<MoviePocBo>();
            result.Add(new MoviePocBo { Id = 1, Title = "Movie 1" });
            result.Add(new MoviePocBo { Id = 2, Title = "Movie 2" });
            return await Task.FromResult(result);
        }
    }
}
