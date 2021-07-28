using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UtilityCore;
using WebCoreConstants;
using WebCoreDbContext;
using WebCoreEntities;
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

            services.AddSingleton<TestSingoltoneLifeCycle, TestSingoltoneLifeCycle>();
            services.AddScoped<TestScopedLifeCycle, TestScopedLifeCycle>();
            services.AddTransient<TestTransientLfieCycle, TestTransientLfieCycle>();
            services.AddSingleton<EnviuornmentValues, EnviuornmentValues>();
            services.AddScoped<StudentMSContext, StudentMSContext>();
            services.AddScoped<LoginUserIdentityRepository, LoginUserIdentityRepository>();
            services.AddScoped<LoginUserIdentityService, LoginUserIdentityService>();
            services.AddScoped<SubjectRepository, SubjectRepository>();
            services.AddScoped<SubjectService, SubjectService>();
            services.AddScoped<IStudentRepository,StudentRepository> ();
            services.AddScoped<IStudentService, StudentService>(); //ioc +depency injection 

            ///If cookie based Auth
            //services.AddAuthentication(Constants.AuthCookieScheama)
            //    .AddCookie(Constants.AuthCookieScheama, x =>
            //    {
            //        x.LoginPath = "/Login/Index";
            //        x.LogoutPath = "/Login/Index";

            //        x.AccessDeniedPath = "/Unauth/index";
            //        x.ExpireTimeSpan = TimeSpan.FromMinutes(20);

            //    });

            ///If Session Based Auth 
            services.AddAuthentication(Constants.AuthCookieScheama);

            services.AddSession(x => {
                x.IdleTimeout = TimeSpan.FromMinutes(20);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, LoginUserIdentityService loginUserIdentityService)
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


            app.Map("/data", HandleMapTest2);

            app.UseRouting();
            app.UseAuthentication();

          
            app.Use(async (context, next) =>
            {

             //   await context.Response.WriteAsync(DateTime.Now.ToString());
                try
                {
                    await next();
                } 
                catch(Exception ex)
                {
                    await context.Response.WriteAsync("There is exception");
                }

                await context.Response.WriteAsync(DateTime.Now.ToString());
            });

                //app.Run(async (context) =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                //If session Base Authentication 
                if (1 == 1)
            {
                app.Use(async (context, next) =>
                {
                    if (string.IsNullOrWhiteSpace(context?.User?.Identity?.Name))
                    {
                        var arr = context.Session.Get("userObject");
                        var user = ConvertData.ByteArrayToObject<LoginUserIdentity>(arr);
                        if (user != null)
                        {
                            context.User = loginUserIdentityService.GetClaimsPrincipal(user);
                        }
                    }
                    await next();
                });
            }
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapControllerRoute(
                //   name: "xyz",
                //   pattern: "product/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName:"Admin",
                    pattern: "admin/{controller=HomeData}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Student}/{action=Index}/{id?}");
            });
        }

        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Request.Path = new PathString("/login");
                context.Request.PathBase = new PathString("/login");
                //   await context.Response.WriteAsync(DateTime.Now.ToString());
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    await context.Response.WriteAsync("There is exception");
                }

                await context.Response.WriteAsync(DateTime.Now.ToString());
            });
        }
    }


   

}
