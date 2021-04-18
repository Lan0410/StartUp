using ISCommon.Constant;
using ISWeb.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ISWeb.Security
{
    public class ISSignInManager : ISignManager
    {
        IConfiguration _config;
        public ISSignInManager()
        {
        }

        public ISSignInManager(IConfiguration config)
        {
            _config = config;
        }

        public async void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(userCD, userName, userRole), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() { IsPersistent = isPersistent };
            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties
            );
        }

        public async void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, string authenticationScheme, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(userCD, userName, userRole), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() { IsPersistent = isPersistent };
            await httpContext.SignInAsync(
              authenticationScheme, principal, authenticationProperties
            );
        }

        public async void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, object loginInfo, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(userCD, userName, userRole, loginInfo), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() { IsPersistent = isPersistent };
            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties
            );
        }
        public async void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, string roleName, object loginInfo, object lstUserRole, object lstRoleFunctionPermission, object lstMenu, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(userCD, userName, userRole, roleName, loginInfo, lstUserRole, lstRoleFunctionPermission, lstMenu), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() { IsPersistent = isPersistent };
            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties
            );
        }

        public async void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, List<string> permissions, object loginInfo, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(userCD, userName, userRole, loginInfo, permissions), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() { IsPersistent = isPersistent };
            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties
            );
        }

        public async void SignIn(HttpContext httpContext, string userCD, string userName, string userRole, object loginInfo, string authenticationScheme, bool isPersistent = false)
        {
            int loginTimeOut = 0;
            var rs = int.TryParse(_config["Security:LoginTimeOut"], out loginTimeOut);
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(userCD, userName, userRole, loginInfo), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() { IsPersistent = isPersistent, ExpiresUtc = DateTime.UtcNow.AddMinutes(loginTimeOut) };
            await httpContext.SignInAsync(
              authenticationScheme, principal, authenticationProperties
            );
            httpContext.User = principal;
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            LoginUnLock(httpContext);
        }

        public async void SignOut(HttpContext httpContext, string authenticationScheme)
        {
            await httpContext.SignOutAsync(authenticationScheme);
            LoginUnLock(httpContext);
        }
       
        public SignInLock LoginLocked(HttpContext HttpContext)
        {
            bool SupportsLockout = false;
            var rs = bool.TryParse(_config["Security:SupportsLockout"], out SupportsLockout);
            int loginTimeLock = 0;
            int loginCountLock = 0;
            if (SupportsLockout)
            {
                rs = int.TryParse(_config["Security:LockoutTimeSpan"], out loginTimeLock);
                rs = int.TryParse(_config["Security:LockoutMaxFailedAccessAttempts"], out loginCountLock);
                if (loginTimeLock > 0)
                {
                    var LoginTime = HttpContext.Session.GetDateTime("LoginTimeLock");
                    if (LoginTime != null)
                    {
                        DateTime CurrentTime = DateTime.Now;
                        TimeSpan c = CurrentTime.Subtract(DateTime.Parse(LoginTime.ToString()));
                        if (c.TotalMinutes <= loginTimeLock)
                        {
                            return new SignInLock()
                            {
                                IsLock = true,
                                TimeLock = loginCountLock,
                                TimeUnLock = ((loginTimeLock - c.TotalMinutes) * 60) + 15
                            };
                        }
                    }
                }
            }
            return new SignInLock()
            {
                IsLock = false,
                TimeLock = loginCountLock,
                TimeUnLock = 0
            };
        }


        public bool LoginLock(HttpContext httpContext)
        {

            bool SupportsLockout = false;
            var rs = bool.TryParse(_config["Security:SupportsLockout"], out SupportsLockout);
            if (SupportsLockout)
            {
                int loginCountLock = 0;
                rs = int.TryParse(_config["Security:LockoutMaxFailedAccessAttempts"], out loginCountLock);
                int loginFail = httpContext.Session.Get<int>("LoginFail");
                if (loginFail >= loginCountLock)
                    loginFail = 0;
                loginFail++;
                httpContext.Session.Set("LoginFail", loginFail);
                if (loginFail >= loginCountLock)
                {
                    httpContext.Session.Set("LoginTimeLock", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"));
                    httpContext.Session.Set("LoginTime", string.Empty);
                    return true;
                }
            }
            return false;
        }

        public void LoginUnLock(HttpContext httpContext)
        {
            httpContext.Session.Set<int>("LoginFail", 0);
            httpContext.Session.Set<DateTime?>("LoginTimeLock", null);
            httpContext.Session.Set<DateTime?>("LoginTime", DateTime.Now);
        }

        public long GetCurrentUserId(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return -1;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim == null)
                return -1;

            long currentUserId;

            if (!long.TryParse(claim.Value, out currentUserId))
                return -1;

            return currentUserId;
        }

        public int GetCurrentRole(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return 0;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (claim == null)
                return 0;


            return Convert.ToInt32(claim.Value);
        }
        public string GetUserName(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return "";

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            if (claim == null)
                return "";


            return claim.Value;
        }
        public string GetRoleName(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return "";

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == Constant.SessionKey.RoleName);

            if (claim == null)
                return "";


            return claim.Value;
        }
        private IEnumerable<Claim> GetUserClaims(string userCD, string userName, string userRole)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, userCD));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            //claims.AddRange(this.GetUserRoleClaims(userRole));
            return claims;
        }

        private IEnumerable<Claim> GetUserClaims(string userCD, string userName, string userRole, List<string> permissions)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, userCD));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            List<Claim> claimPermissions = new List<Claim>();
            foreach (string permission in permissions)
            {
                claims.Add(new Claim("Permission", permission));
            }
            claims.AddRange(claimPermissions);
            return claims;
        }
      
        private IEnumerable<Claim> GetUserClaims(string userCD, string userName, string userRole, object loginInfo)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, userCD));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(loginInfo)));
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            return claims;
        }
        private IEnumerable<Claim> GetUserClaims(string userCD, string userName, string userRole, string roleName, object loginInfo, object lstUserRole, object lstRoleFunctionPermission, object lstMenu)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, userCD));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            claims.Add(new Claim(Constant.SessionKey.RoleName, roleName));
            claims.Add(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(loginInfo)));
            claims.Add(new Claim(Constant.SessionKey.RoleUser, JsonConvert.SerializeObject(lstUserRole)));
            claims.Add(new Claim(Constant.SessionKey.Permission, JsonConvert.SerializeObject(lstRoleFunctionPermission)));
            claims.Add(new Claim(Constant.SessionKey.MenuUser, JsonConvert.SerializeObject(lstMenu)));
            return claims;
        }

        private IEnumerable<Claim> GetUserClaims(string userCD, string userName, string userRole, object loginInfo, List<string> permissions)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, userCD));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(loginInfo)));
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            List<Claim> claimPermissions = new List<Claim>();
            foreach (string permission in permissions)
            {
                //Permission permission = this.storage.Permissions.Find(permissionId);

                claims.Add(new Claim("Permission", permission));
            }
            claims.AddRange(claimPermissions);
            return claims;
        }

        public Dictionary<string, string> UserData(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData);

            if (claim == null)
                return null;

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(claim.Value);
        }
        public List<Dictionary<string, string>> GetListUserRole(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == Constant.SessionKey.RoleUser);

            if (claim == null)
                return null;

            return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(claim.Value);
        }
        public List<Dictionary<string, string>> GetListPermission(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == Constant.SessionKey.Permission);

            if (claim == null)
                return null;

            return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(claim.Value);
        }
        public List<Dictionary<string, string>> GetListMenu(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == Constant.SessionKey.MenuUser);

            if (claim == null)
                return null;

            return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(claim.Value);
        }
    }
}
