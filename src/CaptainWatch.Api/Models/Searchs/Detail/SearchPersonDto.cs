using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using System.ComponentModel.DataAnnotations;

namespace CaptainWatch.Api.Models.Searchs.Detail
{
    public class SearchPersonDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Required]
        public double RankingScore { get; set; }
    }

    public static class SearchPersonExtensions
    {
        public static SearchPersonBo ToBo(this SearchPersonDto person)
        {
            return new SearchPersonBo
            {
                Id = person.Id,
                Name = person.Name,
                RankingScore = person.RankingScore
            };
        }
    }
}
