using CaptainWatch.Api.Domain.Bo.Movies.Result;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface IMovieRepo
    {
        Task<IEnumerable<MoviePocBo>> GetMoviesPoc();
    }
}
