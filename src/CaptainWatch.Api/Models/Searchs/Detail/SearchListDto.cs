using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
using System.ComponentModel.DataAnnotations;

namespace CaptainWatch.Api.Models.Searchs.Detail
{
    public class SearchListDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }

    public static class SearchListExtensions
    {
        public static SearchListBo ToBo(this SearchListDto list)
        {
            return new SearchListBo
            {
                Id = list.Id,
                Name = list.Name
            };
        }
    }
}
