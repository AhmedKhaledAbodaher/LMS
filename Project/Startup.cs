using DomainLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.IRepo;
using RepositoryLayer.UnitOfWork;
using Serilog;
using ServiceLayer.BaseService.MaterialService;
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

            #region Repo
            Type[] repositories = Assembly.Load(typeof(Material).Assembly.GetName()).GetTypes().Where(r => r.Name.EndsWith("Repo")).ToArray();
            Type[] iRepositories = Assembly.Load(typeof(IMaterialRepository).Assembly.GetName()).GetTypes().Where(r => r.IsInterface && r.Name.EndsWith("Repo")).ToArray();
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
            Type[] appServices = Assembly.Load(typeof(MaterilaService).Assembly.GetName()).GetTypes().Where(r => r.IsClass && r.Name.EndsWith("Service")).ToArray();
            Type[] iappServices = Assembly.Load(typeof(IMaterilaService).Assembly.GetName()).GetTypes().Where(r => r.IsInterface && r.Name.EndsWith("Service")).ToArray();
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
