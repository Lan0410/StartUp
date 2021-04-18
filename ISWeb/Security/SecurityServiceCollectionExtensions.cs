using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using ISWeb.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Http.Features;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json.Serialization;
using ISCommon.Constant;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SecurityServiceCollectionExtensions
    {
       
        //public static void AddISMvc(this IServiceCollection services, IConfiguration configuration, Dictionary<string, string> schemes)
        //{
        //    services.AddMvc(options =>
        //    {
        //        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        //    }).AddNewtonsoftJson(options =>
        //    options.SerializerSettings.ContractResolver = new
        //    DefaultContractResolver()).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false)
        //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        //    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        //    .AddDataAnnotationsLocalization();
        //    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //    services.AddControllersWithViews();
        //    services.AddAntiforgery(o => o.HeaderName = "X-CSRF-TOKEN");
        //    services.AddSession();
        //    services.AddScoped<ISignManager, ISSignInManager>();
        //    var MimeTypes = new[]
        //                     {
        //                            // General
        //                            "text/plain",
        //                            // Static files
        //                            "text/css",
        //                            "application/javascript",
        //                            // MVC
        //                            "text/html",
        //                            "application/xml",
        //                            "text/xml",
        //                            "application/json",
        //                            "text/json",
        //                            "image/svg+xml",
        //                            "application/atom+xml"
        //                        };
        //    services.AddResponseCompression(options =>
        //    {
        //        options.EnableForHttps = true;
        //        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(MimeTypes); ;
        //        options.Providers.Add<GzipCompressionProvider>();
        //    });
        //    services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
        //    services.Configure<FormOptions>(x =>
        //    {
        //        x.ValueLengthLimit = Int32.MaxValue;
        //        x.MultipartBodyLengthLimit = Int32.MaxValue;
        //        x.MultipartHeadersLengthLimit = Int32.MaxValue;
        //    });
          
        //    int loginTimeOut = 0;
        //    var rs = int.TryParse(configuration[Constant.Config.Security], out loginTimeOut);    
        //    foreach (string key in schemes.Keys)
        //    {
        //        services.AddAuthentication(key).AddCookie(key, o =>
        //        {
        //            o.LoginPath = new PathString(schemes[key]);
        //            o.ExpireTimeSpan = TimeSpan.FromDays(loginTimeOut);
        //            o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        //            o.Events = new ISCookieAuthenticationEvents();
        //        });
        //    }
        //    services.Configure<CookiePolicyOptions>(options =>
        //    {
        //        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //        options.CheckConsentNeeded = context => false;
        //        options.MinimumSameSitePolicy = SameSiteMode.None;
        //    });
        //}

        //public static void AddISMvc(this IServiceCollection services, IConfiguration configuration, string loginPage)
        //{           
        //    services.AddMvc(options =>
        //    {
        //        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        //    }).AddNewtonsoftJson(options =>
        //    options.SerializerSettings.ContractResolver = new
        //    DefaultContractResolver()).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false)
        //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        //    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        //    .AddDataAnnotationsLocalization();
        //    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //    services.AddControllersWithViews();
        //    services.AddAntiforgery(o => o.HeaderName = "X-CSRF-TOKEN");
        //    services.AddSession();
        //    services.AddScoped<ISignManager, ISSignInManager>();
        //    var MimeTypes = new[]
        //                     {
        //                            // General
        //                            "text/plain",
        //                            // Static files
        //                            "text/css",
        //                            "application/javascript",
        //                            // MVC
        //                            "text/html",
        //                            "application/xml",
        //                            "text/xml",
        //                            "application/json",
        //                            "text/json",
        //                            "image/svg+xml",
        //                            "application/atom+xml"
        //                        };
        //    services.AddResponseCompression(options =>
        //    {
        //        options.EnableForHttps = true;
        //        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(MimeTypes); ;
        //        options.Providers.Add<GzipCompressionProvider>();
        //    });
        //    services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
        //    services.Configure<FormOptions>(x =>
        //    {
        //        x.ValueLengthLimit = Int32.MaxValue;
        //        x.MultipartBodyLengthLimit = Int32.MaxValue;
        //        x.MultipartHeadersLengthLimit = Int32.MaxValue;
        //    });
            
        //    int loginTimeOut = 0;
        //    var rs = int.TryParse(configuration[Constant.Config.Security], out loginTimeOut);
        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //    }).AddCookie(options => {
        //        options.LoginPath = new PathString(loginPage); 
        //        options.LogoutPath = new PathString(loginPage);
        //        options.ExpireTimeSpan = TimeSpan.FromDays(loginTimeOut);
        //        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        //        options.Events = new ISCookieAuthenticationEvents();
        //    });
        //    services.Configure<CookiePolicyOptions>(options =>
        //    {
        //        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //        options.CheckConsentNeeded = context => false;
        //        options.MinimumSameSitePolicy = SameSiteMode.None;
        //    });
        //   // services.AddNCacheDistributedCache();
        //}
    }
}
