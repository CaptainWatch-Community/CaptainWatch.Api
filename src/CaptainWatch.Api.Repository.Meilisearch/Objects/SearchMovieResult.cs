namespace CaptainWatch.Api.Repository.Meilisearch.Objects;

public class SearchMovieResult : SearchMovie
{
    public double _rankingScore { get; set; }
}