using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ISWeb.Security
{
    public interface ISignManager
    {
        SignInLock LoginLocked(HttpContext httpContext);
        void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, bool isPersistent = false);
        void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, object loginInfo, bool isPersistent = false);
        void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, List<string> permissions, object loginInfo, bool isPersistent = false);
        Dictionary<string,string> UserData(HttpContext httpContext);
        void SignOut(HttpContext httpContext);
        long GetCurrentUserId(HttpContext httpContext);
        int GetCurrentRole(HttpContext httpContext);
    }
}
