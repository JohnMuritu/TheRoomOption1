using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using option_one.Data;
using option_one.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace option_one.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly PromoCodesDBContext _context;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            PromoCodesDBContext context
            ) : base(options, logger, encoder, clock)
        {
            _context = context;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header was not found");

            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] creadentials = Encoding.UTF8.GetString(bytes).Split(":");
                string username = creadentials[0];
                string password = creadentials[1];

                User user = _context.Users.Where(u => u.username == username).Where(u => u.password == password).FirstOrDefault();

                if (user == null)
                    return AuthenticateResult.Fail("Invalid credentials");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.username) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception)
            {

                return AuthenticateResult.Fail("Error has occured");
            }

        }
    }
}
