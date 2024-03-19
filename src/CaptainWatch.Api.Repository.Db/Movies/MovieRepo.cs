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

        public async Task DeleteMovie(int movieId)
        {
            await _dbContext.Procedures.DeleteMovieAsync(movieId);
        }

        public async Task<IEnumerable<MoviePocBo>> GetMoviesPoc()
        {
            var movies = await _dbContext.Movie.Take(10).ToListAsync();
            return movies.ToBoPoc();
        }

        public async Task<IEnumerable<MovieBo>> GetMoviesWithPositiveSiteScore()
        {
            var movies = await _dbContext.Movie.Where(_ => _.SiteScore > 0).Select(_ => new MovieBo
            {
                Id = _.Id,
                Title = _.Title
            }).ToListAsync();
            return movies;
        }
    }
}
