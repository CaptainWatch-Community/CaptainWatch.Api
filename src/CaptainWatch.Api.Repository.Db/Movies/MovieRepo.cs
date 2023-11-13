using CaptainWatch.Api.Domain.Bo.Movies.Result;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Repository.Db.Movies
{
    public class MovieRepo : IMovieRepo
    {
        public async Task<IEnumerable<MoviePocBo>> GetMoviesPoc()
        {
            var result = new List<MoviePocBo>();
            result.Add(new MoviePocBo { Id = 1, Title = "Movie 1 Repo" });
            result.Add(new MoviePocBo { Id = 2, Title = "Movie 2 Repo" });
            return await Task.FromResult(result);
        }
    }
}
