using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface IUserRepo
    {
        Task<IEnumerable<SearchUserAddOrUpdateBo>> GetAllUsersForSearch();

    }
}
