namespace CaptainWatch.Api.Domain.Bo.Searchs.Detail
{
    public class SearchMovieBo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? MinReleaseDate { get; set; }
        public double RankingScore { get; set; }

    }
}
