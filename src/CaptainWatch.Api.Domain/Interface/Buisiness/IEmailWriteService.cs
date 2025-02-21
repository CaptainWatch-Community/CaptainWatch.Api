using CaptainWatch.Api.Domain.Bo.Emails.Request;

namespace CaptainWatch.Api.Domain.Interface.Buisiness
{
    public interface IEmailWriteService
    {
        Task SendTransactionalHtml(EmailRequestHtmlBo request);
        Task SendTransactionalWelcomePassword(EmailRequestWelcomePasswordBo request);
        Task SendTransactionalResetPassword(EmailRequestResetPasswordBo request);


		Task SendNotificationHtml(EmailRequestHtmlBo request);
	}
}
