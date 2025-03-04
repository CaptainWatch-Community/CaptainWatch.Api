using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface IMovieRepo
    {
        Task<IEnumerable<MoviePocBo>> GetMoviesPoc();
        Task<IEnumerable<MovieBo>> GetMoviesWithPositiveSiteScore();
        Task DeleteMovie(int movieId);
        Task<IEnumerable<SearchMovieAddOrUpdateBo>> GetAllMoviesForSearch();
		Task UpdateWishCount();
	}
}
