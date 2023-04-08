using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using DomainLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.MiddleWare;
using Repository.IRepo;
using Repository.Repo;
using RepositoryLayer.UnitOfWork;
using Serilog;
using ServiceLayer.Mapping;
using ServiceLayer.Service.MaterialService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>
                (s=>s.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddAutoMapper(typeof(ApplicationProfiler).Assembly);
            #region Repo
            Type[] repositories = Assembly.Load(typeof(MaterialRepository).Assembly.GetName()).
                GetTypes().Where(r => r.Name.EndsWith("Repository")).ToArray();
            Type[] iRepositories = Assembly.Load(typeof(IMaterialRepository).Assembly.GetName()).GetTypes().Where(r => r.IsInterface && r.Name.EndsWith("Repository")).ToArray();
            foreach (var repoInterface in iRepositories)
            {
                System.Type classType = repositories.FirstOrDefault(r => repoInterface.IsAssignableFrom(r));
                if (classType != null)
                {
                    services.AddScoped(repoInterface, classType);
                }
            }
            #endregion

            #region Services

            Type[] appServices = Assembly.Load(typeof(VideoService).Assembly.GetName()).GetTypes().Where(r => r.IsClass && r.Name.EndsWith("Service")).ToArray();
            Type[] iappServices = Assembly.Load(typeof(ILevelService).Assembly.GetName()).GetTypes().Where(r => r.IsInterface && r.Name.EndsWith("Service")).ToArray();
            foreach (var serviceInterface in iappServices)
            {
                System.Type classType = appServices.FirstOrDefault(r => serviceInterface.IsAssignableFrom(r));
                if (classType != null)
                {
                    services.AddScoped(serviceInterface, classType);
                }
            }

            #endregion
            #region UOF
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            #endregion
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseNotyf();

            //    app.UseMiddleware<GlobalErrorHandling>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
