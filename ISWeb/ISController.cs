using ISWeb.Client;
using ISWeb.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using ISWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Web;
using ISCommon.Constant;

namespace ISWeb
{
    public class ISController : Controller
    {
        public UserAgent User_Agent;
        public readonly ITempDataProvider _tempDataProvider;
        public readonly IServiceProvider _serviceProvider;
        public IHttpContextAccessor _httpContextAccessor;
        public ISSignInManager SignInManager;
        public readonly ILogger _logger;
        public readonly IConfiguration _config;
        bool isAjax;
        public int LoginTimeOut = 0;
        public bool EnabelLogin = true;
        public bool TimeOut = false;
        protected int PageSize = 0;
        public static string VersionJs = "";
        public string LogPath = "";
        public string FilePath = "";
        public string ClientBrowserVersion = "";
        public int ClientBrowserMajorVersion = 0;
        public double ClientBrowserMinorVersion = 0.0;
        public string ClientBrowserType = "";
        public string ClientOS = "";
        public string ClientBrowser = "";
        public string ClientBrowser2 = "";
        public string ClientDevice = "";
        public string Language = "vi-VN";
        public string LanguageShort = "vi";
        public string PreviousUrl = null;
        public string CurrentUrl = null;
        public string RefererUrl = null;
        public string RefLink = null;
        public bool IsAdmin = false;
        public string ftpAccount;
        public string ftpPassword;
        public ISController(IHttpContextAccessor httpContextAccessor,IConfiguration config, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider, ILogger<object> logger)
        {
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _logger = logger;
            SignInManager = new ISSignInManager(config);
            var rs = int.TryParse(_config["DefaultPageSize"], out PageSize);
            VersionJs = _config["VersionJS"];
            LogPath = _config["LogPath"];         
            RefLink = _config["RefLink"];
            FilePath = _config["FTPAccount:Path"];
            ftpAccount = config["FTPAccount:UserName"];
            ftpPassword = config["FTPAccount:Password"];
            if (!string.IsNullOrEmpty(_config["IsAdmin"]))
                IsAdmin =Convert.ToBoolean(_config["IsAdmin"]);

        }

        public ISController(IConfiguration config)
        {
            _config = config;
            SignInManager = new ISSignInManager(config);
        }
        public Dictionary<string, string> UserData
        {
            get { return SignInManager.UserData(HttpContext); }
        }
        public List<Dictionary<string, string>> ListUserRole
        {
            get { return SignInManager.GetListUserRole(HttpContext); }
        }
        public List<Dictionary<string, string>> ListPermission
        {
            get { return SignInManager.GetListPermission(HttpContext); }
        }
        public List<Dictionary<string, string>> ListMenu
        {
            get { return SignInManager.GetListMenu(HttpContext); }
        }
        public string GetUserData(string key)
        {
            try
            {
                return SignInManager.UserData(HttpContext)[key];
            }
            catch
            {
                return "";
            }
        }
        public string BaseUrl
        {
            get
            {
                return HttpContext.BaseUrl();
            }
        }

        public long UserId
        {
            get { return SignInManager.GetCurrentUserId(HttpContext); }
        }
        public int UserType
        {
            get
            {
                var userData = SignInManager.UserData(HttpContext);
                int _userType = Constant.UserType.Admin;
                int.TryParse(userData["UserType"], out _userType);
                return _userType;
            }
        }
        public int UserRole
        {
            get { return SignInManager.GetCurrentRole(HttpContext); }
        }
        public string UserName
        {
            get { return SignInManager.GetUserName(HttpContext); }
        }
        public string RoleName
        {
            get { return SignInManager.GetRoleName(HttpContext); }
        }
        public string Token
        {
            get
            {
                var userData = SignInManager.UserData(HttpContext);
                return userData["TokenKey"];
            }
        }
        public string UserDefaultLanguage
        {
            get
            {
                var userData = SignInManager.UserData(HttpContext);
                return userData["DefaultLangguage"];
            }
        }
        public string RemoteIp()
        {
            return Request.HttpContext.Connection.RemoteIpAddress.ToString();
        }       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lstMenu = _httpContextAccessor.HttpContext.Session.Get<List<Dictionary<string, string>>>(Constant.SessionKey.MenuUser);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated || lstMenu == null || !lstMenu.Any())
            {
                SignInManager.SignOut(_httpContextAccessor.HttpContext);
                filterContext.Result = new RedirectResult("/Admin/Account");
                return;
            }
            var headers = filterContext.HttpContext.Request.Headers;
            var userAgent = headers["User-Agent"].ToString();           
            UserAgent ua = new UserAgent(userAgent);
            ClientDevice = ISDevice.GetDeviceType(userAgent);

            filterContext.HttpContext.Items["ClientOS"] = ClientOS = ua.OS.Name + " " + ua.OS.Version;
            filterContext.HttpContext.Items["ClientBrowser2"] = ClientBrowser2 = ua.Browser.Name + " " + ua.Browser.Version;
            filterContext.HttpContext.Items["ClientBrowser"] = ClientBrowser = ClientBrowserType = ua.Browser.Name;
            filterContext.HttpContext.Items["RefererUrl"] = RefererUrl = HttpContext.Request.Headers[HeaderNames.Referer];

            var regex = new Regex(@"(?:\b(MS)?IE\s+|\bTrident\/7\.0;.*\s+rv:)(\d+)");
            var match = regex.Match(userAgent);
            if (match.Success)
            {
                filterContext.HttpContext.Items["ClientBrowserType"] = ClientBrowserType = "Internet Explorer";
            }
            else if (ClientBrowserType.Contains("Firefox")) // replace with your check
            {
                filterContext.HttpContext.Items["ClientBrowserType"] = ClientBrowserType = "Firefox";
            }
            else
            {
                filterContext.HttpContext.Items["ClientBrowserType"] = ClientBrowserType = ua.Browser.Name;
            }           
         
            //try
            //{
            //    if (!string.IsNullOrEmpty(UserDefaultLanguage))
            //    {
                    
            //        filterContext.HttpContext.Items["ClientHttpLanguage"] = Convert.ToString(CultureInfo.CreateSpecificCulture(UserDefaultLanguage));
            //        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(UserDefaultLanguage);
            //        LanguageShort = CultureInfo.DefaultThreadCurrentCulture.TwoLetterISOLanguageName;
            //        Language = CultureInfo.DefaultThreadCurrentCulture.Name;
            //    }
            //    else
            //    {
            //        string[] languages = filterContext.HttpContext.Request.Headers[HeaderNames.AcceptLanguage];
            //        if (languages != null)
            //        {
            //            languages = languages[0].ToLowerInvariant().Trim().Split(';');
            //            string language = languages[0].ToLowerInvariant().Trim();
            //            filterContext.HttpContext.Items["ClientHttpLanguage"] = Language = Convert.ToString(CultureInfo.CreateSpecificCulture(language));
            //            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(Language);
            //            //LanguageShort = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            //            LanguageShort = CultureInfo.DefaultThreadCurrentCulture.TwoLetterISOLanguageName;
            //        }
            //        else
            //        {
            //            Language = "vi-VN";
            //            LanguageShort = "vi";
            //            filterContext.HttpContext.Items["ClientHttpLanguage"] = Convert.ToString(CultureInfo.CreateSpecificCulture(Language));
            //            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(Language);
            //        }
            //    }
            //}
            //catch (ArgumentException)
            //{
            //    Language = "vi-VN";
            //    LanguageShort = "vi";
            //    filterContext.HttpContext.Items["ClientHttpLanguage"] = Language = null;
               
            //}
            List<string> PreviousUrls = filterContext.HttpContext.Session.Get<List<string>>("PreviousUrls");
            if (PreviousUrls == null)
                PreviousUrls = new List<string>();
            filterContext.HttpContext.Items["IsAjax"] = isAjax = false;
            string page = "";
            if (headers.Keys.Contains("X-Requested-With") && headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.HttpContext.Items["IsAjax"] = isAjax = true;
                try
                {
                    page = filterContext.HttpContext.Request.Form["page"];
                }
                catch { }
            }
            else if (headers.Keys.Contains("x-requested-with") && headers["x-requested-with"] == "XMLHttpRequest")
            {
                filterContext.HttpContext.Items["IsAjax"] = isAjax = true;
                try
                {
                    page = filterContext.HttpContext.Request.Form["page"];
                }
                catch { }
            }
            else
            {
                var requestedWith = Convert.ToString(filterContext.HttpContext.Request.Query["X-Requested-With"]);
                if (!string.IsNullOrEmpty(requestedWith) && requestedWith == "XMLHttpRequest")
                {
                    filterContext.HttpContext.Items["IsAjax"] = isAjax = true;
                    try
                    {
                        page = filterContext.HttpContext.Request.Form["page"];
                    }
                    catch { 
                    }
                }
                else
                {
                    PreviousUrls = SetPreviousUrl(PreviousUrls);
                }
            }
            filterContext.HttpContext.Items["PreviousUrl"] = PreviousUrl = null;
            if (PreviousUrls.Count > 1)
            {
                filterContext.HttpContext.Items["PreviousUrl"] = PreviousUrl = PreviousUrls[PreviousUrls.Count - 2];
            }
            if (PreviousUrls.Count > 0)
            {
                filterContext.HttpContext.Items["CurrentUrl"] = CurrentUrl = PreviousUrls[PreviousUrls.Count - 1];
            }
           
        }
        private List<string> SetPreviousUrlPost(List<string> PreviousUrls)
        {
            var last = PreviousUrls.Count > 0 ? PreviousUrls[PreviousUrls.Count - 1] : null;
            UriBuilder rq = new UriBuilder(HttpContext.Request.Headers[HeaderNames.Referer]);
            var qstr = HttpUtility.ParseQueryString(rq.Query);             
            string strUri = rq.ToString();
            List<KeyValuePair<string, StringValues>> forms = HttpContext.Request.Form.ToList();
            foreach (KeyValuePair<string, StringValues> ii in forms)
            {
                string v = ii.Value;
                if (!string.IsNullOrEmpty(v))
                {
                    if (qstr.AllKeys.Contains(ii.Key))
                        qstr[ii.Key] = v;
                    else
                        qstr.Add(ii.Key, v);

                }
            }
            if (qstr.AllKeys.Count() > 0)
            {
                rq.Query = qstr.ToString();
            }
            return PreviousUrls;
        }

        private List<string> SetPreviousUrl(List<string> PreviousUrls)
        {
            if (UserId > 0)
            {
                string currentUri = "";
                try
                {
                    currentUri = PreviousUrls[PreviousUrls.Count - 1];
                }
                catch { currentUri = ""; }
                string strUri = "";
                try
                {
                    strUri = HttpContext.Request.Path;
                }
                catch { strUri = ""; }
                if (HttpContext.Request.Method == "GET")
                {
                    if (strUri != null && strUri.ToLower().IndexOf("login") < 0 && strUri.ToLower().IndexOf("error") < 0 && strUri != currentUri)
                    {
                        PreviousUrls.Add(strUri);
                        HttpContext.Session.Set("PreviousUrls", PreviousUrls);
                    }
                }
            }            
            return PreviousUrls;
        }


        public void SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }       
       
       
        public void ErrorLog(string system, string screen_id, string action, string error_type, string error_cd, string error_message)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                string directory = Path.Combine((!string.IsNullOrEmpty(LogPath) ? LogPath : AppDomain.CurrentDomain.BaseDirectory),  "Logs",currentDate.ToString("yyyy-MM"));
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                directory += @"\" + currentDate.Month;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string title = "[error_datetime][ipaddress][screen_id][action][error_type][error_cd][error_message][browser][user_cd][OS][system]";
                if (!System.IO.File.Exists(directory + @"\" + currentDate.ToString("yyyyMMdd") + "_error_log.txt"))
                {
                    using (StreamWriter writer = System.IO.File.AppendText(directory + @"\" + currentDate.ToString("yyyyMMdd") + "_error_log.txt"))
                    {
                        writer.WriteLine(title);
                        writer.Close();
                    }
                }
                using (StreamWriter writer = System.IO.File.AppendText(directory + @"\" + currentDate.ToString("yyyyMMdd") + "_error_log.txt"))
                {
                    string log_msg = string.Format("[{0}][{1}][{2}][{3}][{4}][{5}][{6}][{7}][{8}][{9}][{10}]", DateTime.Now.ToString("ddd, MMM d, yyyy HH:mm:ss"), RemoteIp(), screen_id, action, error_type, error_cd, error_message, ClientBrowser2, UserId, ClientOS, system);
                    writer.WriteLine(log_msg);
                    writer.Close();
                }
            }
            catch (Exception ex) { }

        }
        public IActionResult MessageLayout(string viewName, string title, string message, string backUrl, string note = "")
        {
            TempDataDictionary tempData = new TempDataDictionary(HttpContext, _tempDataProvider);
            tempData.Add("Title", title);
            tempData.Add("Message", message);
            tempData.Add("Note", note);
            tempData.Add("BaseUrl", BaseUrl);
            tempData.Add("BackUrl", backUrl);
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.DisplayName;        
            PartialViewResult partialView = new PartialViewResult();
            partialView.ViewName = viewName;
            partialView.TempData = tempData;
            partialView.ViewData = ViewData;
            partialView.ViewEngine = _serviceProvider.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            ActionContext actionContext = new ActionContext();
            partialView.ExecuteResult(actionContext);
            return partialView;
        }

        public string RenderViewToString(string viewName, object model, ITempDataDictionary TempData = null)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.DisplayName;            
            ViewData.Model = model;
            using (StringWriter sw = new StringWriter())
            {
                var engine = _serviceProvider.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine; 
                ViewEngineResult viewResult = engine.FindView(ControllerContext, viewName, false);
                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData == null ? new TempDataDictionary(HttpContext, _tempDataProvider) : TempData,
                    sw,
                    new HtmlHelperOptions() 
                );             
                var t = viewResult.View.RenderAsync(viewContext);
                t.Wait();

                return sw.GetStringBuilder().ToString();
            }

        }
    }
}
