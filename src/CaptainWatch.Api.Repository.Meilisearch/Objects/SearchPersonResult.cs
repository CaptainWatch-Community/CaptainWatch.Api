namespace CaptainWatch.Api.Repository.Meilisearch.Objects;

public class SearchPersonResult : SearchPerson
{
    public double _rankingScore { get; set; }
}