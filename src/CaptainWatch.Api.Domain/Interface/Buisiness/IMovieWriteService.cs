namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface IMovieWriteService
    {
        Task Delete(int movieId);
		Task UpdateWishCount();
	}
}
