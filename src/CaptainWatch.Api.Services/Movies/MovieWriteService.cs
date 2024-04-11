using CaptainWatch.Api.Domain.Bo.Movies.Result;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class MovieWriteService : IMovieWriteService
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;

        public MovieWriteService(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        #endregion
        public async Task Delete(int movieId)
        {
            await _movieRepo.DeleteMovie(movieId);
        }
    }
}
