using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Models.Movies.Detail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers
{
    [Route("api/movie")]
    [ApiController]
    [Authorize]
    public class MovieReadController : ControllerBase
    {
        #region Declarations

        private readonly IMovieServiceRead _movieServiceRead;

        public MovieReadController(IMovieServiceRead movieServiceRead)
        {
            _movieServiceRead = movieServiceRead;
        }

        #endregion

        /// <summary>
        /// Get all movies poc
        /// </summary>
        [HttpGet("poc")]
        [ActionName("GetMoviesPoc")]
        [SwaggerOperation(Tags = new[] { "Movie" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MoviePocDto>>> GetMovies()
        {
            var movies = await _movieServiceRead.GetMoviesPoc();
            return Ok(movies.ToDto());
        }
    }
}
