using CaptainWatch.Api.Domain.Bo.Movies.Result;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class MovieServiceWrite : IMovieServiceWrite
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;

        public MovieServiceWrite(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        #endregion
        public async Task DeleteMovie(int movieId)
        {
            /*return await _movieRepo.GetMoviesPoc();*/
            var lidwine = "Killian";
        }
    }
}
