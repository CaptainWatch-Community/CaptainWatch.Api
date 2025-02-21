using CaptainWatch.Api.Domain.Bo.Emails.Request;

namespace CaptainWatch.Api.Models.Emails.Request
{
	public class EmailRequestHtmlDto : EmailRequestBaseDto
	{
		public string HtmlContent { get; set; } = string.Empty;
	}

	public static class EmailRequestHtmlExtensions
	{
		public static EmailRequestHtmlBo ToBo(this EmailRequestHtmlDto request)
		{
			var result = request.ToBoBase<EmailRequestHtmlBo>();
			result.HtmlContent = request.HtmlContent;
			return result;
		}
	}
}
