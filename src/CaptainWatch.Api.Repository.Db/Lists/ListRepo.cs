using CaptainWatch.Api.Domain.Bo.Sitemaps.Detail;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using Microsoft.EntityFrameworkCore;

namespace CaptainWatch.Api.Repository.Db.Lists
{
    public class ListRepo : IListRepo
    {
        private readonly CaptainWatchContext _dbContext;

        public ListRepo(CaptainWatchContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SitemapListBo>> GetLists()
        {
            var lists = await _dbContext.List.Select(_ => new SitemapListBo
            {
                Id = _.Id,
                Name = _.Name
            }).ToListAsync();
            return lists;
        }
    }
}
