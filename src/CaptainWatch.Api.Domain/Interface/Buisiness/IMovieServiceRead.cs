using CaptainWatch.Api.Domain.Bo.Movies.Result;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface IMovieServiceRead
    {
        Task<IEnumerable<MoviePocBo>> GetMoviesPoc();
    }
}
