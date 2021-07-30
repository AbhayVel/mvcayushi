using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UtilityCore;
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

        [ResponseCache(Duration =  30, Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            ViewBag.currentDate = DateTime.Now.ToString();
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
            if (1==2)
            {
                var claimPrinsiple = LoginUserIdentityService.GetClaimsPrincipalByName(userName, password);
                if (claimPrinsiple != null)
                {
                    await HttpContext.SignInAsync(Constants.AuthCookieScheama, claimPrinsiple);
                    HttpContext.User = claimPrinsiple;
                    return Redirect("/Student/index");
                }
            }             
            if (1==1)
            {
                var loginUserIdentity = LoginUserIdentityService.GetLoginUserIdentityByName(userName, password);
                var byteArr = ConvertData.ObjectToByteArray(loginUserIdentity);
                HttpContext.Session.Set("userObject", byteArr);
                HttpContext.User = LoginUserIdentityService.GetClaimsPrincipal(loginUserIdentity);
                return Redirect("/Student/index");
            }

            return View("Index");
           
        }
    }
}
