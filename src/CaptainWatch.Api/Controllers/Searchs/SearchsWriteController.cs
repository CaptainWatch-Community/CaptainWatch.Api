using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Models.Searchs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Movies
{
    [Route("api/searchs")]
    [ApiController]
    [Authorize]
    public class SearchsWriteController : ControllerBase
    {
        #region Declarations

        private readonly ISearchWriteService _searchWriteService;

        public SearchsWriteController(ISearchWriteService searchWriteService)
        {
            _searchWriteService = searchWriteService;
        }

        #endregion

        [HttpPut("movies")]
        [SwaggerOperation(Summary = "Import all movies into the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ImportAllMovies()
        {
            await _searchWriteService.ImportAllMovies();
            return NoContent();
        }


        [HttpPut("movies/{movieId}")]
        [SwaggerOperation(Summary = "Add or Update a movie in the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> AddOrUpdateMovie(int movieId, [FromBody] SearchMovieAddOrUpdateDto movie)
        {
            var movieBo = movie.ToBo();
            movieBo.Id = movieId;
            await _searchWriteService.AddOrUpdateMovie(movieBo);
            return NoContent();
        }


        [HttpDelete("movies/{movieId}")]
        [SwaggerOperation(Summary = "Delete a movie from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteMovie(int movieId)
        {
            await _searchWriteService.DeleteMovie(movieId);
            return NoContent();
        }


        [HttpDelete("movies")]
        [SwaggerOperation(Summary = "Delete all movies from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAllMovies()
        {
            await _searchWriteService.DeleteAllMovies();
            return NoContent();
        }
    }
}
