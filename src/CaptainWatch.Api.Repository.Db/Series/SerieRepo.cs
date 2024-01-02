﻿using CaptainWatch.Api.Domain.Bo.Series.Result;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using CaptainWatch.Api.Repository.Db.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CaptainWatch.Api.Repository.Db.Series
{
    public class SerieRepo : ISerieRepo
    {
        private readonly CaptainWatchContext _dbContext;

        public SerieRepo(CaptainWatchContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SerieBo>> GetSeriesWithPositiveSiteScore()
        {
            var series = await _dbContext.Tv.Where(_ => _.SiteScore > 0).ToListAsync();
            return series.ToBo();
        }
    }
}
