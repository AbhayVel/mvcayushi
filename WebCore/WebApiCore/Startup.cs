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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCoreConstants;
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
            services.AddControllers().AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();
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

            app.UseHttpsRedirection();

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
