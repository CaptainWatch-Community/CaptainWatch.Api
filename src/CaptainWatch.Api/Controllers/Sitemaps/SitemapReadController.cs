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
    }
}
