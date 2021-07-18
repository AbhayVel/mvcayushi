using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCoreConstants;
using WebCoreEntities;
using WebCoreServiceLayer;

namespace WebCore.Controllers
{
    public class LoginController : Controller
    {
        public LoginUserIdentityService LoginUserIdentityService { get; set; }
        public   LoginController(LoginUserIdentityService loginUserIdentityService)
        {
            LoginUserIdentityService = loginUserIdentityService;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {

          await  HttpContext.SignOutAsync();
            
            return View("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Login(string userName,string password)
        {

          var claimPrinsiple =  LoginUserIdentityService.GetClaimsPrincipalByName(userName, password);
            if (claimPrinsiple!=null)
            {                   
              await  HttpContext.SignInAsync(Constants.AuthCookieScheama, claimPrinsiple);
              return Redirect("/Student");
            }
            return View("Index");
        }
    }
}
