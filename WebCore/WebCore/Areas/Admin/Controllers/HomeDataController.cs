using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Areas.Admin.Controllers
{
    public class HomeDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
