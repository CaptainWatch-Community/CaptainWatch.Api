using CaptainWatch.Api.Domain.Interface.Buisiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Movies
{
    [Route("api/movies")]
    [ApiController]
    [Authorize]
    public class MoviesWriteController : ControllerBase
    {
        #region Declarations

        private readonly IMovieServiceWrite _movieServiceWrite;

        public MoviesWriteController(IMovieServiceWrite movieServiceWrite)
        {
            _movieServiceWrite = movieServiceWrite;
        }

        #endregion

        /// <summary>
        /// Delete movie
        /// </summary>
        [HttpDelete("{movieId}")]
        [ActionName("DeleteMovie")]
        [SwaggerOperation(Summary = "Delete movie", Tags = new[] { "Movie" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteMovie(int movieId)
        {
            await _movieServiceWrite.DeleteMovie(movieId);
            return NoContent();
        }
    }
}
