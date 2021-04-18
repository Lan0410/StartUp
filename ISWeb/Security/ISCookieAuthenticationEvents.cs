using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace ISWeb.Security
{
    public class ISCookieAuthenticationEvents: CookieAuthenticationEvents
    {
        public override Task RedirectToAccessDenied(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = 404;
            return Task.FromResult(0);
        }
    }
}
