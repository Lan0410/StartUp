using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IWebLinkRepository, WebLinkRepository>();
            services.AddTransient<IWebLinkBusiness, WebLinkBusiness>();
            services.AddTransient<IMentorRepository,MentorRepository>();
            services.AddTransient<IMentorBusiness, MentorBusiness>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IProvinceBusiness, ProvinceBusiness>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryBusiness, CategoryBusiness>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IGenreBusiness, GenreBusiness>();
            services.AddTransient<ILocaltionRepository, LocaltionRepository>();
            services.AddTransient<ILocaltionBusiness, LocaltionBusiness>();
            services.AddTransient<IGroupPageRepository, GroupPageRepository>();
            services.AddTransient<IGroupPageBusiness, GroupPageBusiness>();
            services.AddTransient<IPageRepository, PageRepository>();
            services.AddTransient<IPageBusiness, PageBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiMiddleware();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();
        }
    }
}
