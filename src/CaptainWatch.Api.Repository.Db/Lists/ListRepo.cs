using CaptainWatch.Api.Domain.Bo.Sitemaps.Result;
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

        public async Task<IEnumerable<ListSitemapBo>> GetLists()
        {
            var lists = await _dbContext.Tv.Where(_ => _.SiteScore > 0).Select(_ => new ListSitemapBo
            {
                Id = _.Id,
                Name = _.Name
            }).ToListAsync();
            return lists;
        }
    }
}
