namespace CaptainWatch.Api.Domain.Bo.Emails.Request
{
	public class EmailRequestBaseBo
	{
		public string Subject { get; set; } = string.Empty;
		public string SenderName { get; set; } = string.Empty;
		public IEnumerable<EmailContactBo> To { get; set; } = new List<EmailContactBo>();
		public IEnumerable<EmailContactBo> Cc { get; set; } = new List<EmailContactBo>();
		public IEnumerable<EmailContactBo> Bcc { get; set; } = new List<EmailContactBo>();
	}
}
