namespace CaptainWatch.Api.Domain.Bo.Emails.Request
{
	public class EmailRequestResetPasswordBo : EmailRequestBaseBo
	{
		public string UserName { get; set; } = string.Empty;
		public string ResetPasswordLink { get; set; } = string.Empty;
	}
}
