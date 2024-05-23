namespace CaptainWatch.Api.Domain.Bo.Searchs.Detail
{
    public class SearchSerieBo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? FirstAirDate { get; set; }
        public double RankingScore { get; set; }

    }
}
