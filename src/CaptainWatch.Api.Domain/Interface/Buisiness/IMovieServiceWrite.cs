using CaptainWatch.Api.Domain.Bo.Movies.Result;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface IMovieServiceWrite
    {
        Task DeleteMovie(int movieId);
    }
}
