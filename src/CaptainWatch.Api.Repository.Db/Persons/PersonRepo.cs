using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using CaptainWatch.Api.Repository.Db.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CaptainWatch.Api.Repository.Db.Users
{
    public class PersonRepo : IPersonRepo
    {
        private readonly CaptainWatchContext _dbContext;

        public PersonRepo(CaptainWatchContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SearchPersonAddOrUpdateBo>> GetAllPersonsForSearch()
        {
            var persons = await _dbContext.Person.Select(PersonExtensions.ProjectionToSearchPersonAddOrUpdateBo).ToListAsync();
            return persons;
        }
    }
}
