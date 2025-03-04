using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class MovieWriteService : IMovieWriteService
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;
        private readonly ISearchWriteService _searchWriteService;

        public MovieWriteService(IMovieRepo movieRepo, ISearchWriteService searchWriteService)
        {
            _movieRepo = movieRepo;
            _searchWriteService = searchWriteService;
        }

        #endregion
        public async Task Delete(int movieId)
        {
            await _movieRepo.DeleteMovie(movieId);
            await _searchWriteService.DeleteMovie(movieId);
        }

		public async Task UpdateWishCount()
		{
			await _movieRepo.UpdateWishCount();
		}
	}
}
