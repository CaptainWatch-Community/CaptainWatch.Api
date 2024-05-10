namespace CaptainWatch.Api.Domain.Bo.Movies.Detail
{
    public class MovieBo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? MinReleaseDate { get; set; }
    }
}
