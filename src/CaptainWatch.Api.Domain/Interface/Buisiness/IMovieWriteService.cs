using CaptainWatch.Api.Domain.Bo.Movies.Result;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface IMovieWriteService
    {
        Task DeleteMovie(int movieId);
    }
}
