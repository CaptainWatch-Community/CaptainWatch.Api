using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using System.ComponentModel.DataAnnotations;

namespace CaptainWatch.Api.Models.Searchs.Detail
{
    public class SearchUserDto
    {
        [Required]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Pseudo { get; set; } = string.Empty;

        [Required]
        public double RankingScore { get; set; }

    }

    public static class SearchUserExtensions
    {
        public static SearchUserBo ToBo(this SearchUserDto user)
        {
            return new SearchUserBo
            {
                Id = user.Id,
                FullName = user.FullName,
                Pseudo = user.Pseudo,
                RankingScore = user.RankingScore
            };
        }
    }
}
