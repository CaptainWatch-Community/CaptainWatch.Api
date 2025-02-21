using CaptainWatch.Api.Domain.Bo.Emails.Request;

namespace CaptainWatch.Api.Models.Emails.Request
{
	public class EmailRequestBaseDto
	{
		public string Subject { get; set; } = string.Empty;
		public string SenderName { get; set; } = string.Empty;
		public IEnumerable<EmailContactDto> To { get; set; } = new List<EmailContactDto>();
		public IEnumerable<EmailContactDto> Cc { get; set; } = new List<EmailContactDto>();
		public IEnumerable<EmailContactDto> Bcc { get; set; } = new List<EmailContactDto>();
	}

	public static class EmailRequestBaseExtensions
	{
		public static T ToBoBase<T>(this EmailRequestBaseDto request) where T : EmailRequestBaseBo, new()
		{
			return new T
			{
				Subject = request.Subject,
				SenderName = request.SenderName,
				To = request.To.ToBo(),
				Cc = request.Cc.ToBo(),
				Bcc = request.Bcc.ToBo()
			};
		}
	}
}
