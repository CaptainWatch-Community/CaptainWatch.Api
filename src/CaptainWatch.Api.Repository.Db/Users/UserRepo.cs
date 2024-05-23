using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using CaptainWatch.Api.Repository.Db.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CaptainWatch.Api.Repository.Db.Users
{
    public class UserRepo : IUserRepo
    {
        private readonly CaptainWatchContext _dbContext;

        public UserRepo(CaptainWatchContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SearchUserAddOrUpdateBo>> GetAllUsersForSearch()
        {
            var users = await _dbContext.UserProfile.Include(_ => _.ExtraUserInformation).Select(UserExtensions.ProjectionToSearchUserAddOrUpdateBo).ToListAsync();
            return users;
        }
    }
}
