using CaptainWatch.Api.Domain.Bo.Emails.Request;

namespace CaptainWatch.Api.Models.Emails.Request
{
	public class EmailRequestResetPasswordDto : EmailRequestBaseDto
	{
		public string UserName { get; set; } = string.Empty;
		public string ResetPasswordLink { get; set; } = string.Empty;
	}

	public static class EmailRequestResetPasswordExtensions
	{
		public static EmailRequestResetPasswordBo ToBo(this EmailRequestResetPasswordDto request)
		{
			var result = request.ToBoBase<EmailRequestResetPasswordBo>();
			result.UserName = request.UserName;
			result.ResetPasswordLink = request.ResetPasswordLink;
			return result;
		}
	}
}
