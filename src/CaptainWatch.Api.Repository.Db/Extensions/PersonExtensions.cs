using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using System.Linq.Expressions;

namespace CaptainWatch.Api.Repository.Db.Extensions
{
    public static class PersonExtensions
    {

        public static Expression<Func<Person, SearchPersonAddOrUpdateBo>> ProjectionToSearchPersonAddOrUpdateBo => user => new SearchPersonAddOrUpdateBo
        {
            Id = user.Id,
            Name = user.Name
        };
    }
}
