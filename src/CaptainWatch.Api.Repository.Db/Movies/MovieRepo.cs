using CaptainWatch.Api.Domain.Bo.Movies.Result;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using CaptainWatch.Api.Repository.Db.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CaptainWatch.Api.Repository.Db.Movies
{
    public class MovieRepo : IMovieRepo
    {
        private readonly CaptainWatchContext _dbContext;

        public MovieRepo(CaptainWatchContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<MoviePocBo>> GetMoviesPoc()
        {
            var movies = await _dbContext.Movie.Take(10).ToListAsync();
            return movies.ToBo();
        }
    }
}
