namespace CaptainWatch.Api.Repository.Meilisearch.Objects;

public class SearchSerie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string OriginalTitle { get; set; } = string.Empty;
    public DateTime? FirstAirDate { get; set; }

}