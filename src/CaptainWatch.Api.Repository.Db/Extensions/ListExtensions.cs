using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using System.Linq.Expressions;

namespace CaptainWatch.Api.Repository.Db.Extensions
{
    public static class ListExtensions
    {

        public static Expression<Func<List, SearchListAddOrUpdateBo>> ProjectionToSearchListAddOrUpdateBo => user => new SearchListAddOrUpdateBo
        {
            Id = user.Id,
            Name = user.Name
        };
    }
}
