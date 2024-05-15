using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using System.Linq.Expressions;

namespace CaptainWatch.Api.Repository.Db.Extensions
{
    public static class UserExtensions
    {

        public static Expression<Func<UserProfile, SearchUserAddOrUpdateBo>> ProjectionToSearchUserAddOrUpdateBo => user => new SearchUserAddOrUpdateBo
        {
            Id = user.UserId,
            UserName = user.UserName,
            FullName = user.ExtraUserInformation.First().FullName ?? string.Empty,
        };
    }
}
