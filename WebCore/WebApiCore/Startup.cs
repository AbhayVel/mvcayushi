using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCore.Filters;
using WebCoreConstants;
using WebCoreDbContext;
using WebCoreRepositoryLayer;
using WebCoreServiceLayer;

namespace WebApiCore
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


            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Added this code A possible object cycle was detected which is not supported. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
   
).AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();
            // services.AddMvcCore();
            services.AddSingleton<TestSingoltoneLifeCycle, TestSingoltoneLifeCycle>();
            services.AddScoped<TestScopedLifeCycle, TestScopedLifeCycle>();
            services.AddTransient<TestTransientLfieCycle, TestTransientLfieCycle>();
            services.AddSingleton<EnviuornmentValues, EnviuornmentValues>();

           
            services.AddScoped<StudentMSContext, StudentMSContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Test API",
                    Version = "v1",
                    Description = "Test Api.",
                    Contact = new OpenApiContact
                    {
                        Name = "Abhay Vel",
                        Email = string.Empty,
                        Url = new Uri("https://localhost:44392/"),
                    },
                });
                //Add this if Header required
                c.OperationFilter<QdnHeaderFilter>();
            });

            services.AddScoped<LoginUserIdentityRepository, LoginUserIdentityRepository>();
            services.AddScoped<LoginUserIdentityService, LoginUserIdentityService>();

            services.AddScoped<SubjectRepository, SubjectRepository>();
            services.AddScoped<SubjectService, SubjectService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>(); //ioc +depency injection 
                                                                   //ioc +depency injection 

            services.AddAuthentication(x =>
            {
                //   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; if Default 
                //  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; if Default 

                  x.DefaultAuthenticateScheme = Constants.AuthCookieScheama; // if Custom 
               x.DefaultChallengeScheme = Constants.AuthCookieScheama; // if Custom 

            })
            //.AddJwtBearer(y => if Default 
             .AddJwtBearer(Constants.AuthCookieScheama,y => // if Custom  
             {
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("123456789101234578")),
                    ValidateIssuer=false,
                    ValidateIssuerSigningKey=true,
                    ValidateAudience=false,
            };

                y.Events = new JwtBearerEvents
                {
                    OnMessageReceived = z =>
                    {
                        if (z.Request.Path.ToString().Contains("swagger"))
                        {
                            return Task.CompletedTask;
                        }
                      var str=  z.Request.Headers["token"].ToString();
                        if (string.IsNullOrWhiteSpace(str))
                        {
                            z.NoResult();
                        } else if(str.StartsWith("qdn"))
                        {

                            z.Token = str.Substring(4).Trim();
                        } else
                        {
                            z.NoResult();
                        }


                        return Task.CompletedTask;
                    }
                } ;

                
            });
        
        
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
           
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Api");
                //https://localhost:44392/swagger/ui/index.html
                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = "swagger/ui";
            });
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
