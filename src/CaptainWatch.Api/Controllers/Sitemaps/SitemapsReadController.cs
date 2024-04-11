using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Models.Sitemaps.Detail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Sitemaps
{
    [Route("api/sitemaps")]
    [ApiController]
    [Authorize]
    public class SitemapsReadController : ControllerBase
    {
        #region Declarations

        private readonly ISitemapReadService _sitemapServiceRead;


        public SitemapsReadController(ISitemapReadService sitemapServiceRead)
        {
            _sitemapServiceRead = sitemapServiceRead;
        }

        #endregion

        [HttpGet("movies")]
        [SwaggerOperation(Summary = "Get data to generate a sitemap for movies", Tags = new[] { "Sitemap" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SitemapMovieDto>))]
        public async Task<ActionResult<IEnumerable<SitemapMovieDto>>> GetMovies()
        {
            var movies = await _sitemapServiceRead.GetMovies();
            return Ok(movies.ToDto());
        }

        [HttpGet("series")]
        [SwaggerOperation(Summary = "Get data to generate a sitemap for series", Tags = new[] { "Sitemap" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SitemapSerieDto>))]
        public async Task<ActionResult<IEnumerable<SitemapSerieDto>>> GetSeries()
        {
            var series = await _sitemapServiceRead.GetSeries();
            return Ok(series.ToDto());
        }

        [HttpGet("lists")]
        [SwaggerOperation(Summary = "Get data to generate a sitemap for lists", Tags = new[] { "Sitemap" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SitemapListDto>))]
        public async Task<ActionResult<IEnumerable<SitemapListDto>>> GetLists()
        {
            var lists = await _sitemapServiceRead.GetLists();
            return Ok(lists.ToDto());
        }
    }
}
