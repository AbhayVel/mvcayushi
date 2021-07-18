using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreConstants;
using WebCoreRepositoryLayer;
using WebCoreServiceLayer;

namespace WebCore
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

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddScoped<LoginUserIdentityRepository, LoginUserIdentityRepository>();
            services.AddScoped<LoginUserIdentityService, LoginUserIdentityService>();
            services.AddScoped<SubjectRepository, SubjectRepository>();
            services.AddScoped<SubjectService, SubjectService>();
            services.AddScoped<IStudentRepository,StudentRepository> ();
            services.AddScoped<IStudentService, StudentService>(); //ioc +depency injection 
            services.AddAuthentication(Constants.AuthCookieScheama)
                .AddCookie(Constants.AuthCookieScheama, x =>
                {
                    x.LoginPath = "/Login/Index";
                    x.LogoutPath = "/Login/Index";
                    
                    x.AccessDeniedPath = "/Unauth/index";
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                });
            services.AddSession(x => {
                x.IdleTimeout = TimeSpan.FromMinutes(20);
            });

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
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

         
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapControllerRoute(
                //   name: "xyz",
                //   pattern: "product/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Student}/{action=Index}/{id?}");
            });
        }
    }
}
