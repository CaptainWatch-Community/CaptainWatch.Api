using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Models.Sitemaps.Detail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Sitemaps
{
    [Route("api/sitemap")]
    [ApiController]
    [Authorize]
    public class SitemapReadController : ControllerBase
    {
        #region Declarations

        private readonly ISitemapServiceRead _sitemapServiceRead;


        public SitemapReadController(ISitemapServiceRead sitemapServiceRead)
        {
            _sitemapServiceRead = sitemapServiceRead;
        }

        #endregion

        /// <summary>
        /// Get data to generate a sitemap for movies
        /// </summary>
        [HttpGet("movies")]
        [ActionName("GetMovieSitemapData")]
        [SwaggerOperation(Summary = "Get data to generate a sitemap for movies", Tags = new[] { "Sitemap" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieSitemapDto>>> GetMovieSitemapData()
        {
            var movies = await _sitemapServiceRead.GetMovieSitemapData();
            return Ok(movies.ToDto());
        }

        /// <summary>
        /// Get data to generate a sitemap for series
        /// </summary>
        [HttpGet("series")]
        [ActionName("GetSerieSitemapData")]
        [SwaggerOperation(Summary = "Get data to generate a sitemap for series", Tags = new[] { "Sitemap" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SerieSitemapDto>>> GetSerieSitemapData()
        {
            var series = await _sitemapServiceRead.GetSerieSitemapData();
            return Ok(series.ToDto());
        }

        /// <summary>
        /// Get data to generate a sitemap for lists
        /// </summary>
        [HttpGet("lists")]
        [ActionName("GetListSitemapData")]
        [SwaggerOperation(Summary = "Get data to generate a sitemap for lists", Tags = new[] { "Sitemap" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ListSitemapDto>>> GetListSitemapData()
        {
            var lists = await _sitemapServiceRead.GetListSitemapData();
            return Ok(lists.ToDto());
        }
    }
}
