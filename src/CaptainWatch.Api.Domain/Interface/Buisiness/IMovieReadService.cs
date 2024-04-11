using CaptainWatch.Api.Domain.Bo.Movies.Detail;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface IMovieReadService
    {
        Task<IEnumerable<MoviePocBo>> GetPoc();
    }
}
