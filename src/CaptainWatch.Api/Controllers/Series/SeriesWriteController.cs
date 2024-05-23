using CaptainWatch.Api.Domain.Interface.Buisiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Series
{
    [Route("api/series")]
    [ApiController]
    [Authorize]
    public class SeriesWriteController : ControllerBase
    {
        #region Declarations

        private readonly ISerieWriteService _serieServiceWrite;

        public SeriesWriteController(ISerieWriteService serieServiceWrite)
        {
            _serieServiceWrite = serieServiceWrite;
        }

        #endregion

        [HttpDelete("{serieId}")]
        [SwaggerOperation(Summary = "Delete serie", Tags = new[] { "Serie" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int serieId)
        {
            await _serieServiceWrite.Delete(serieId);
            return NoContent();
        }
    }
}
