using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Models.Movies.Detail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Movies
{
    [Route("api/movies")]
    [ApiController]
    [Authorize]
    public class MoviesReadController : ControllerBase
    {
        #region Declarations

        private readonly IMovieServiceRead _movieServiceRead;

        public MoviesReadController(IMovieServiceRead movieServiceRead)
        {
            _movieServiceRead = movieServiceRead;
        }

        #endregion

        /// <summary>
        /// Get all movies poc
        /// </summary>
        [HttpGet("poc")]
        [ActionName("GetMoviesPoc")]
        [SwaggerOperation(Summary = "Get all movies poc", Tags = new[] { "Movie" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MoviePocDto>>> GetMovies()
        {
            var movies = await _movieServiceRead.GetMoviesPoc();
            return Ok(movies.ToDto());
        }
    }
}
