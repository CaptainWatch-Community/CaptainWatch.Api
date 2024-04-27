using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class SearchWriteService : ISearchWriteService
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;
        private readonly ISearchRepo _searchRepo;

        public SearchWriteService(IMovieRepo movieRepo, ISearchRepo searchRepo)
        {
            _movieRepo = movieRepo;
            _searchRepo = searchRepo;
        }

        #endregion
        public async Task ImportAllMovies()
        {
            var movies = await _movieRepo.GetAllMoviesForSearch();
            await _searchRepo.AddMoviesDocuments(movies);
        }
    }
}
