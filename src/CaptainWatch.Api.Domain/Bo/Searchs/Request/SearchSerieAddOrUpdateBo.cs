namespace CaptainWatch.Api.Domain.Bo.Searchs.Request
{
    public class SearchSerieAddOrUpdateBo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public DateTime? FirstAirDate { get; set; }
    }
}
