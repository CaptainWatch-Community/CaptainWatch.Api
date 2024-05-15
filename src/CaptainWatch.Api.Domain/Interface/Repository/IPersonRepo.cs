using CaptainWatch.Api.Domain.Bo.Searchs.Request;

namespace CaptainWatch.Api.Domain.Interface.Repository
{
    public interface IPersonRepo
    {
        Task<IEnumerable<SearchPersonAddOrUpdateBo>> GetAllPersonsForSearch();

    }
}
