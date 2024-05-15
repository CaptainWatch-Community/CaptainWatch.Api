using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using System.ComponentModel.DataAnnotations;

namespace CaptainWatch.Api.Models.Searchs.Detail
{
    public class SearchUserDto
    {
        [Required]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

    }

    public static class SearchuserExtensions
    {
        public static SearchUserBo ToBo(this SearchUserDto user)
        {
            return new SearchUserBo
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName
            };
        }
    }
}
