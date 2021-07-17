using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBasic.Models;

namespace WebBasic.Controllers
{
    public class HomeController : Controller
    {
        public Employee Index()
        {
            ViewBag.Title = "Home Page";

            Employee e = new Employee();

            TryUpdateModel(e);
            return e;
        }
    }
}
