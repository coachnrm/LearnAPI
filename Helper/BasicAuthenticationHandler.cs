using Microsoft.AspNetCore.Authentication;
using LearnAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace LearnAPI.Helper
{
    public class BasicAuthenticationHandler:AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly LearnDataContext context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, LearnDataContext context) : base(options, logger, encoder, clock)
        {
            this.context = context;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
    }
}