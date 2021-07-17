using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebCoreServiceLayer;

namespace ConsoleAppCoreDI
{
    public class StartUp : IHostedService
    {

        public IStudentService StudentService { get; set; }

        public StartUp(IStudentService studentService)
        {
            StudentService = studentService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var data = StudentService.GetAllStudent();

            foreach(var user in data)
            {
                Console.WriteLine(user.FirstName);
            }

           // str.

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
//Collection //String //date 