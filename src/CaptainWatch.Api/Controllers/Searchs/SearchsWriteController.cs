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

        [HttpPost("config/init")]
        [SwaggerOperation(Summary = "Initialize the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> InitSearchEngine()
        {
            await _searchWriteService.InitSearchEngine();
            return NoContent();
        }


        #region Movies

        [HttpPut("movies")]
        [SwaggerOperation(Summary = "Import all movies into the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ImportAllMovies()
        {
            await _searchWriteService.ImportAllMovies();
            return NoContent();
        }


        [HttpPut("movies/{movieId}")]
        [SwaggerOperation(Summary = "Add or update a movie in the search engine", Tags = new[] { "Search" })]
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

        #endregion

        #region Series

        [HttpPut("series")]
        [SwaggerOperation(Summary = "Import all series into the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ImportAllSeries()
        {
            await _searchWriteService.ImportAllSeries();
            return NoContent();
        }


        [HttpPut("series/{serieId}")]
        [SwaggerOperation(Summary = "Add or update a serie in the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> AddOrUpdateSerie(int serieId, [FromBody] SearchSerieAddOrUpdateDto serie)
        {
            var serieBo = serie.ToBo();
            serieBo.Id = serieId;
            await _searchWriteService.AddOrUpdateSerie(serieBo);
            return NoContent();
        }


        [HttpDelete("series/{serieId}")]
        [SwaggerOperation(Summary = "Delete a serie from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteSerie(int serieId)
        {
            await _searchWriteService.DeleteSerie(serieId);
            return NoContent();
        }


        [HttpDelete("series")]
        [SwaggerOperation(Summary = "Delete all series from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAllSeries()
        {
            await _searchWriteService.DeleteAllSeries();
            return NoContent();
        }

        #endregion

        #region Users

        [HttpPut("users")]
        [SwaggerOperation(Summary = "Import all users into the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ImportAllUsers()
        {
            await _searchWriteService.ImportAllUsers();
            return NoContent();
        }


        [HttpPut("users/{userId}")]
        [SwaggerOperation(Summary = "Add or update a user in the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> AddOrUpdateUser(int userId, [FromBody] SearchUserAddOrUpdateDto user)
        {
            var userBo = user.ToBo();
            userBo.Id = userId;
            await _searchWriteService.AddOrUpdateUser(userBo);
            return NoContent();
        }


        [HttpDelete("users/{userId}")]
        [SwaggerOperation(Summary = "Delete a user from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _searchWriteService.DeleteUser(userId);
            return NoContent();
        }


        [HttpDelete("users")]
        [SwaggerOperation(Summary = "Delete all users from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAllUsers()
        {
            await _searchWriteService.DeleteAllUsers();
            return NoContent();
        }


        #endregion

        #region Persons

        [HttpPut("persons")]
        [SwaggerOperation(Summary = "Import all persons into the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ImportAllPersons()
        {
            await _searchWriteService.ImportAllPersons();
            return NoContent();
        }


        [HttpPut("persons/{personId}")]
        [SwaggerOperation(Summary = "Add or update a person in the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> AddOrUpdatePerson(int personId, [FromBody] SearchPersonAddOrUpdateDto person)
        {
            var personBo = person.ToBo();
            personBo.Id = personId;
            await _searchWriteService.AddOrUpdatePerson(personBo);
            return NoContent();
        }


        [HttpDelete("persons/{personId}")]
        [SwaggerOperation(Summary = "Delete a person from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeletePerson(int personId)
        {
            await _searchWriteService.DeletePerson(personId);
            return NoContent();
        }


        [HttpDelete("persons")]
        [SwaggerOperation(Summary = "Delete all persons from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAllPersons()
        {
            await _searchWriteService.DeleteAllPersons();
            return NoContent();
        }

        #endregion

        #region Lists

        [HttpPut("lists")]
        [SwaggerOperation(Summary = "Import all lists into the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ImportAllLists()
        {
            await _searchWriteService.ImportAllLists();
            return NoContent();
        }


        [HttpPut("lists/{listId}")]
        [SwaggerOperation(Summary = "Add or update a list in the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> AddOrUpdateList(int listId, [FromBody] SearchListAddOrUpdateDto list)
        {
            var listBo = list.ToBo();
            listBo.Id = listId;
            await _searchWriteService.AddOrUpdateList(listBo);
            return NoContent();
        }


        [HttpDelete("lists/{listId}")]
        [SwaggerOperation(Summary = "Delete a list from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteList(int listId)
        {
            await _searchWriteService.DeleteList(listId);
            return NoContent();
        }


        [HttpDelete("lists")]
        [SwaggerOperation(Summary = "Delete all lists from the search engine", Tags = new[] { "Search" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAllLists()
        {
            await _searchWriteService.DeleteAllLists();
            return NoContent();
        }

        #endregion
    }
}
