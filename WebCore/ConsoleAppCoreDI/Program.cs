using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebCoreRepositoryLayer;
using WebCoreServiceLayer;

namespace ConsoleAppCoreDI
{
    class Program
    {
        static  void Main(string[] args)
        {
            Host.CreateDefaultBuilder().ConfigureServices((hostcontext, services) =>
            {
                services.AddScoped<IStudentRepository, StudentRepository>();
                services.AddScoped<IStudentService, StudentService>(); //ioc +depency injection 
                services.AddSingleton<EMployeeRepo>();
                services.AddSingleton<EmployeeService>();
                services.AddHostedService<StartUp>();

            }).Build().Run();
        }
    }



}
