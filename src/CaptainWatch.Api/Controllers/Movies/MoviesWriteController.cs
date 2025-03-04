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

        private readonly IMovieWriteService _movieServiceWrite;

        public MoviesWriteController(IMovieWriteService movieServiceWrite)
        {
            _movieServiceWrite = movieServiceWrite;
        }

        #endregion

        [HttpDelete("{movieId}")]
        [SwaggerOperation(Summary = "Delete movie", Tags = new[] { "Movie" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int movieId)
        {
            await _movieServiceWrite.Delete(movieId);
            return NoContent();
        }

		[HttpPut("wish-count")]
		[SwaggerOperation(Summary = "Update wish count of all movies", Tags = new[] { "Movie" })]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> UpdateWishCount()
		{
			await _movieServiceWrite.UpdateWishCount();
			return NoContent();
		}

	}
}
