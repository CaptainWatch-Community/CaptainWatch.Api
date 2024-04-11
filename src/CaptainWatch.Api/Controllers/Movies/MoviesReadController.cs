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
        [SwaggerOperation(Summary = "Poc api to get 10 movies", Tags = new[] { "Movie" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MoviePocDto>))]
        public async Task<ActionResult<IEnumerable<MoviePocDto>>> GetPoc()
        {
            var movies = await _movieServiceRead.GetPoc();
            return Ok(movies.ToDto());
        }
    }
}
