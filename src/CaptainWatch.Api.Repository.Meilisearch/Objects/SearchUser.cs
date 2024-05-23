namespace CaptainWatch.Api.Repository.Meilisearch.Objects;

public class SearchUser
{
    public int Id { get; set; }
    public string Pseudo { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;

}