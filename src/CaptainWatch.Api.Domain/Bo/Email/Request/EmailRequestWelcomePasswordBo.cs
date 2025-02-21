using CaptainWatch.Api.Domain.Bo.Movies.Detail;

namespace CaptainWatch.Api.Domain.Bo.Emails.Request
{
    public class EmailRequestWelcomePasswordBo : EmailRequestBaseBo
	{
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string ChangePasswordLink { get; set; } = string.Empty;
	}
}
