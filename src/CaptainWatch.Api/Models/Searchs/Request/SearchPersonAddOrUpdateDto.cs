using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchPersonAddOrUpdateDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public static class SearchPersonAddOrUpdateExtensions
    {
        public static SearchPersonAddOrUpdateBo ToBo(this SearchPersonAddOrUpdateDto person)
        {
            return new SearchPersonAddOrUpdateBo
            {
                Name = person.Name
            };
        }
    }
}
