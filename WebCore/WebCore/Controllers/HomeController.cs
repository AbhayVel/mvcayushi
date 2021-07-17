using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UtilityCore;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index()
        {
          
            return View("other");
        }


         
        public async Task<IActionResult> Save()
        {

            //Employee e = new Employee();
            //Employee employee = new Employee();

            //Address ad = new Address();

            //var include = new string[] { "department.address", "name" };
            //Address ad1 = new Address();
            //await TryUpdateModelAsync(ad, "department.address", propertyFilter: isInclude);
            //await   TryUpdateModelAsync(employee);

            ////Binders.MyModelBinder(ad1, Request, "department.address");
            ////Binders.MyModelBinder(e, Request);
           
            return View("other");
        }

        static bool isInclude(ModelMetadata x)
        {
            var value = x.Name.ToLower().Equals("address1");
            return value;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
