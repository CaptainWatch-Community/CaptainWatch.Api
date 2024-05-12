using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Models.Searchs.Detail;
using CaptainWatch.Api.Models.Searchs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Movies
{
    [Route("api/searchs")]
    [ApiController]
    [Authorize]
    public class SearchsReadController : ControllerBase
    {
        #region Declarations

        private readonly ISearchReadService _searchreadService;

        public SearchsReadController(ISearchReadService searchReadService)
        {
            _searchreadService = searchReadService;
        }

        #endregion


        [HttpPost("movies")]
        [SwaggerOperation(Summary = "Search movies", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SearchMovieDto>))]
        public async Task<ActionResult<IEnumerable<SearchMovieDto>>> SearchMovies([FromBody] SearchMovieQueryDto query)
        {
            var movies = await _searchreadService.SearchMovies(query.ToBo());
            return Ok(movies);
        }


    }
}
