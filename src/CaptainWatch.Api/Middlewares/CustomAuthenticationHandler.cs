using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace CaptainWatch.Api.Middlewares
{
    public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        public CustomAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IConfiguration configuration)
            : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["Authorization"].ToString();
            var authorizedTokens = _configuration.GetSection("AuthorizedTokens").Get<Dictionary<string, string>>();

            if (authorizedTokens != null && authorizedTokens.Values.Any(t => t == token))
            {
                var claims = new[] { new Claim(ClaimTypes.Name, "User") };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
        }
    }

}
