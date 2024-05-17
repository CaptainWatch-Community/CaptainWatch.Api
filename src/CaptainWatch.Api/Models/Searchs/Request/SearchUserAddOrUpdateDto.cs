using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Models.Searchs.Request
{
    public class SearchUserAddOrUpdateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Pseudo { get; set; } = string.Empty;
    }

    public static class SearchUserAddOrUpdateExtensions
    {
        public static SearchUserAddOrUpdateBo ToBo(this SearchUserAddOrUpdateDto user)
        {
            return new SearchUserAddOrUpdateBo
            {
                FullName = user.FullName,
                Pseudo = user.Pseudo
            };
        }
    }
}
