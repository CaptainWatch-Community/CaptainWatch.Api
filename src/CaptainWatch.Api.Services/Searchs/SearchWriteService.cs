using CaptainWatch.Api.Domain.Bo.Searchs.Request;
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

        public async Task DeleteAllMovies()
        {
            await _searchRepo.DeleteAllMoviesDocuments();
        }

        public async Task DeleteMovie(int movieId)
        {
            await _searchRepo.DeleteMovieDocument(movieId);
        }

        public async Task ImportAllMovies()
        {
            var movies = await _movieRepo.GetAllMoviesForSearch();
            await _searchRepo.AddMoviesDocuments(movies);
        }

        public async Task AddOrUpdateMovie( SearchMovieAddOrUpdateBo movie)
        {
            await _searchRepo.AddOrUpdateMovieDocument(movie);
        }
    }
}
