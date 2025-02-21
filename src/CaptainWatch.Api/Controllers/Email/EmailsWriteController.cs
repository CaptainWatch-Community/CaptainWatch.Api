using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Models.Emails.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaptainWatch.Api.Controllers.Emails
{
	[Route("api/emails")]
	[ApiController]
	[Authorize]
	public class EmailsWriteController : ControllerBase
	{
		#region Declarations

		private readonly IEmailWriteService _emailServiceWrite;

		public EmailsWriteController(IEmailWriteService emailServiceWrite)
		{
			_emailServiceWrite = emailServiceWrite;
		}

		#endregion

		[HttpPost("transactional/html")]
		[SwaggerOperation(Summary = "Send an e-mail with HTML content", Tags = new[] { "Email" })]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> SendTransactionalHtml([FromBody] EmailRequestHtmlDto request)
		{
			var requestBo = request.ToBo();
			await _emailServiceWrite.SendTransactionalHtml(requestBo);
			return NoContent();
		}

		[HttpPost("transactional/WelcomePassword")]
		[SwaggerOperation(Summary = "Send an e-mail with template for Welcome and password", Tags = new[] { "Email" })]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> SendTransactionalWelcomePassword([FromBody] EmailRequestWelcomePasswordDto request)
		{
			var requestBo = request.ToBo();
			await _emailServiceWrite.SendTransactionalWelcomePassword(requestBo);
			return NoContent();
		}

		[HttpPost("transactional/ResetPassword")]
		[SwaggerOperation(Summary = "Send an e-mail with template for Reset Password", Tags = new[] { "Email" })]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> SendTransactionalResetPassword([FromBody] EmailRequestResetPasswordDto request)
		{
			var requestBo = request.ToBo();
			await _emailServiceWrite.SendTransactionalResetPassword(requestBo);
			return NoContent();
		}

		[HttpPost("notification/html")]
		[SwaggerOperation(Summary = "Send an e-mail notification with HTML content", Tags = new[] { "Email" })]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> SendNotificationHtml([FromBody] EmailRequestHtmlDto request)
		{
			var requestBo = request.ToBo();
			await _emailServiceWrite.SendNotificationHtml(requestBo);
			return NoContent();
		}

	}
}