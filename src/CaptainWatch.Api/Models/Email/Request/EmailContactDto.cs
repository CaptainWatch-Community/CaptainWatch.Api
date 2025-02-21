using CaptainWatch.Api.Domain.Bo.Emails.Request;

namespace CaptainWatch.Api.Models.Emails.Request
{
	public class EmailContactDto
	{
		public string Email { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
	}

	public static class EmailContactExtensions
	{
		public static EmailContactBo ToBo(this EmailContactDto emailContact)
		{
			return new EmailContactBo
			{
				Email = emailContact.Email,
				Name = emailContact.Name
			};
		}

		public static IEnumerable<EmailContactBo> ToBo(this IEnumerable<EmailContactDto> e)
		{
			return e.Select(_ => _.ToBo());
		}
	}
}
