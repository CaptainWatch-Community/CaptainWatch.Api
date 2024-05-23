namespace CaptainWatch.Api.Repository.Meilisearch.Objects;

public class SearchMovie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string OriginalTitle { get; set; } = string.Empty;
    public DateTime? MinReleaseDate { get; set; }

}