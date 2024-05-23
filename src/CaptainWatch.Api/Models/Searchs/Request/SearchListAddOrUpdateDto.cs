using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchListAddOrUpdateDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public static class SearchListAddOrUpdateExtensions
    {
        public static SearchListAddOrUpdateBo ToBo(this SearchListAddOrUpdateDto list)
        {
            return new SearchListAddOrUpdateBo
            {
                Name = list.Name
            };
        }
    }
}
