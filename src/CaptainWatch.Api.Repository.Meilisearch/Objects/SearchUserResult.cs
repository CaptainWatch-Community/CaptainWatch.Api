namespace CaptainWatch.Api.Repository.Meilisearch.Objects;

public class SearchUserResult : SearchUser
{
    public double _rankingScore { get; set; }
}