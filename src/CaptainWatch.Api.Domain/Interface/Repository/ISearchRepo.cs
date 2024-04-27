using CaptainWatch.Api.Domain.Bo.Movies.Detail;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface ISearchRepo
    {
        Task AddMoviesDocuments(IEnumerable<MovieBo> movies);
    }
}
