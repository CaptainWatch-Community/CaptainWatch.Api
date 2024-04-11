using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class MovieReadService : IMovieReadService
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;

        public MovieReadService(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        #endregion
        public async Task<IEnumerable<MoviePocBo>> GetPoc()
        {
            return await _movieRepo.GetMoviesPoc();
        }
    }
}
