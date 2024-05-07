using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface ISearchRepo
    {
        Task AddMoviesDocuments(IEnumerable<MovieBo> movies);
        Task DeleteMovieDocument(int movieId);
        Task AddOrUpdateMovieDocument(int movieId, SearchMovieAddOrUpdateBo movie);
        Task DeleteAllMoviesDocuments();
    }
}
