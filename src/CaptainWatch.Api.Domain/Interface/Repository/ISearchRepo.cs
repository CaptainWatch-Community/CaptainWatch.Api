using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface ISearchRepo
    {
        Task AddMoviesDocuments(IEnumerable<SearchMovieAddOrUpdateBo> movies);
        Task DeleteMovieDocument(int movieId);
        Task AddOrUpdateMovieDocument(SearchMovieAddOrUpdateBo movie);
        Task DeleteAllMoviesDocuments();
    }
}
