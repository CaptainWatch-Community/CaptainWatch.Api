using CaptainWatch.Api.Domain.Bo.Emails.Request;

namespace CaptainWatch.Api.Models.Emails.Request
{
	public class EmailRequestWelcomePasswordDto : EmailRequestBaseDto
	{
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string ChangePasswordLink { get; set; } = string.Empty;
	}

	public static class EmailRequesttWelcomePasswordExtensions
	{
		public static EmailRequestWelcomePasswordBo ToBo(this EmailRequestWelcomePasswordDto request)
		{
			var result = request.ToBoBase<EmailRequestWelcomePasswordBo>();
			result.UserName = request.UserName;
			result.Email = request.Email;
			result.Password = request.Password;
			result.ChangePasswordLink = request.ChangePasswordLink;
			return result;
		}
	}
}
