using CaptainWatch.Api.Domain.Bo.Emails.Request;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Mjml.Net;


namespace CaptainWatch.Api.Services.Movies
{
	public class EmailWriteService : IEmailWriteService
	{
		#region Declarations

		private readonly IConfiguration _configuration;

		private readonly string _senderEmail;

		private readonly string _smtpHostGmail;
		private readonly int _smtpPortGmail;
		private readonly string _clientIdGmail;
		private readonly string _clientSecretGmail;
		private readonly string _refreshTokenGmail;

		private readonly string _smtpHostBrevo;
		private readonly int _smtpPortBrevo;
		private readonly string _loginBrevo;
		private readonly string _passwordBrevo;

		private static TokenResponse? _tokenResponseGmail;

		public EmailWriteService(IConfiguration configuration)
		{
			_configuration = configuration;

			_senderEmail = _configuration["EmailSettings:SenderEmail"] ?? throw new Exception("Missing configuration key :EmailSettings:SenderEmail");

			_smtpHostGmail = _configuration["EmailSettings:Gmail:SmtpHost"] ?? throw new Exception("Missing configuration key :EmailSettings:Gmail:SmtpHost");
			_smtpPortGmail = int.TryParse(_configuration["EmailSettings:Gmail:SmtpPort"], out int port)
						? port
						: throw new Exception("Missing or invalid configuration key: EmailSettings:Gmail:SmtpPort");
			_clientIdGmail = _configuration["EmailSettings:Gmail:ClientId"] ?? throw new Exception("Missing configuration key :EmailSettings:Gmail:ClientId");
			_clientSecretGmail = _configuration["EmailSettings:Gmail:ClientSecret"] ?? throw new Exception("Missing configuration key :EmailSettings:Gmail:ClientSecret");
			_refreshTokenGmail = _configuration["EmailSettings:Gmail:RefreshToken"] ?? throw new Exception("Missing configuration key :EmailSettings:Gmail:RefreshToken");

			_smtpHostBrevo = _configuration["EmailSettings:Brevo:SmtpHost"] ?? throw new Exception("Missing configuration key :EmailSettings:Brevo:SmtpHost");
			_smtpPortBrevo = int.TryParse(_configuration["EmailSettings:Brevo:SmtpPort"], out int portBrevo)
						? portBrevo
						: throw new Exception("Missing or invalid configuration key: EmailSettings:Brevo:SmtpPort");
			_loginBrevo = _configuration["EmailSettings:Brevo:Login"] ?? throw new Exception("Missing configuration key :EmailSettings:Brevo:Login");
			_passwordBrevo = _configuration["EmailSettings:Brevo:Password"] ?? throw new Exception("Missing configuration key :EmailSettings:Brevo:Password");
		}

		#endregion

		public async Task SendTransactionalHtml(EmailRequestHtmlBo request)
		{
			var accessToken = await GetGoogleOAuth2Token();
			var message = BuildEmailMessage(request, request.HtmlContent);
			await SendTransactionalEmail(message, accessToken);
		}

		public async Task SendTransactionalWelcomePassword(EmailRequestWelcomePasswordBo request)
		{
			var accessToken = await GetGoogleOAuth2Token();

			var template = File.ReadAllText("EmailTemplates/WelcomePassword.mjml");

			template = template.Replace("{{UserName}}", request.UserName)
				.Replace("{{Email}}", request.Email)
				.Replace("{{Password}}", request.Password)
				.Replace("{{ChangePasswordLink}}", request.ChangePasswordLink);

			var mjmlRenderer = new MjmlRenderer();
			var (html, errors) = mjmlRenderer.Render(template, new MjmlOptions { Beautify = false });

			var message = BuildEmailMessage(request, html);
			await SendTransactionalEmail(message, accessToken);
		}

		public async Task SendTransactionalResetPassword(EmailRequestResetPasswordBo request)
		{
			var accessToken = await GetGoogleOAuth2Token();

			var template = File.ReadAllText("EmailTemplates/ResetPassword.mjml");

			template = template.Replace("{{UserName}}", request.UserName)
				.Replace("{{ResetPasswordLink}}", request.ResetPasswordLink);

			var mjmlRenderer = new MjmlRenderer();
			var (html, errors) = mjmlRenderer.Render(template, new MjmlOptions { Beautify = false });

			var message = BuildEmailMessage(request, html);
			await SendTransactionalEmail(message, accessToken);
		}

		public async Task SendNotificationHtml(EmailRequestHtmlBo request)
		{
			var message = BuildEmailMessage(request, request.HtmlContent);
			await SendNotificationEmail(message);
		}

		#region Private Methods
		private MimeMessage BuildEmailMessage(EmailRequestBaseBo request, string htmlContent)
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress(request.SenderName, _senderEmail));
			foreach (var to in request.To) message.To.Add(new MailboxAddress(to.Name, to.Email));
			foreach (var cc in request.Cc) message.Cc.Add(new MailboxAddress(cc.Name, cc.Email));
			foreach (var bcc in request.Bcc) message.Bcc.Add(new MailboxAddress(bcc.Name, bcc.Email));
			message.Subject = request.Subject;
			message.Body = new TextPart("html") { Text = htmlContent };
			return message;
		}

		private async Task SendTransactionalEmail(MimeMessage message, string accessToken)
		{
			using (var client = new SmtpClient())
			{
				client.Connect(_smtpHostGmail, _smtpPortGmail, SecureSocketOptions.StartTls);
				client.Authenticate(new SaslMechanismOAuth2(_senderEmail, accessToken));
				await client.SendAsync(message);
				client.Disconnect(true);
			}
		}

		private async Task SendNotificationEmail(MimeMessage message)
		{
			using (var client = new SmtpClient())
			{
				client.Connect(_smtpHostBrevo, _smtpPortBrevo, SecureSocketOptions.StartTls);
				client.Authenticate(_loginBrevo, _passwordBrevo);
				await client.SendAsync(message);
				client.Disconnect(true);
			}
		}

		private async Task<string> GetGoogleOAuth2Token()
		{
			if (_tokenResponseGmail == null || _tokenResponseGmail.IsStale)
			{
				var clientSecrets = new ClientSecrets { ClientId = _clientIdGmail, ClientSecret = _clientSecretGmail };
				var credential = new UserCredential(
					new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
					{
						ClientSecrets = clientSecrets,
						Scopes = new[] { "https://mail.google.com/" }
					}),
					"user",
					new TokenResponse { RefreshToken = _refreshTokenGmail }
				);

				if (await credential.RefreshTokenAsync(CancellationToken.None))
				{
					_tokenResponseGmail = credential.Token;
				}
				else
				{
					throw new Exception("Failed to refresh the OAuth2 token.");
				}
			}

			return _tokenResponseGmail.AccessToken;
		}
		#endregion
	}
}