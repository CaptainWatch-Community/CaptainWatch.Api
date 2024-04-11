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

        private readonly IMovieReadService _movieServiceRead;

        public MoviesReadController(IMovieReadService movieServiceRead)
        {
            _movieServiceRead = movieServiceRead;
        }

        #endregion

        [HttpGet("poc")]
        [ActionName("GetMoviesPoc")]
        [SwaggerOperation(Summary = "Get all movies poc", Tags = new[] { "Movie" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviePocDto))]
        public async Task<ActionResult<IEnumerable<MoviePocDto>>> GetMovies()
        {
            var movies = await _movieServiceRead.GetMoviesPoc();
            return Ok(movies.ToDto());
        }
    }
}
