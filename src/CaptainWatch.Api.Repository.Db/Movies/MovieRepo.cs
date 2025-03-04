using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;
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

        public async Task<IEnumerable<SearchMovieAddOrUpdateBo>> GetAllMoviesForSearch()
        {
            var movies = await _dbContext.Movie.Select(MovieExtensions.ProjectionToSearchMovieAddOrUpdateBo).ToListAsync();
            return movies;
        }

		public async Task UpdateWishCount()
		{
            await _dbContext.Movie
                .ExecuteUpdateAsync(setter => setter.SetProperty(
                    m => m.WatchlistCount,
                    m => _dbContext.Wish
					    .Where(w => w.MovieId == m.Id)
						.GroupBy(w => w.MovieId)
                        .Select(g => (int?)g.Count()) //Cast to (int?) to handle NULL
						.FirstOrDefault() //Return NULL if no records found
				));
        }

	}
}
