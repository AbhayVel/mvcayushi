using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCoreEntities;

namespace WebCore.Controllers
{
    public class LoginController : Controller
    {
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
            if ("ayushi".Equals(userName))
            {

                LoginUserIdentity loginUser = new LoginUserIdentity();
                loginUser.Name = userName;
                loginUser.IsAuthenticated = true;
                loginUser.AuthenticationType = CookieAuthenticationDefaults.AuthenticationScheme;
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                claimsIdentity.AddClaim(new Claim("Student", "READ"));
                claimsIdentity.AddClaim(new Claim("Admin", "Yes"));
                List<ClaimsIdentity> claimsIdentities = new List<ClaimsIdentity>();
                claimsIdentities.Add(claimsIdentity);
                ClaimsPrincipal claimPrinsiple = new ClaimsPrincipal(claimsIdentities);                 
              await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrinsiple);

                return Redirect("/Student");
            }
            else if("abhay".Equals(userName))
            {

                LoginUserIdentity loginUser = new LoginUserIdentity();
                loginUser.Name = userName;
                loginUser.IsAuthenticated = true;
                loginUser.AuthenticationType = CookieAuthenticationDefaults.AuthenticationScheme;
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "student"));
                claimsIdentity.AddClaim(new Claim("Student", "R"));
                List<ClaimsIdentity> claimsIdentities = new List<ClaimsIdentity>();
                claimsIdentities.Add(claimsIdentity);
                ClaimsPrincipal claimPrinsiple = new ClaimsPrincipal(claimsIdentities);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrinsiple);

                return Redirect("/Student");
            }
            if ("rupal".Equals(userName))
            {

                LoginUserIdentity loginUser = new LoginUserIdentity();
                loginUser.Name = userName;
                loginUser.IsAuthenticated = true;
                loginUser.AuthenticationType = CookieAuthenticationDefaults.AuthenticationScheme;
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "student"));
                claimsIdentity.AddClaim(new Claim("Student", "REA"));
                List<ClaimsIdentity> claimsIdentities = new List<ClaimsIdentity>();
                claimsIdentities.Add(claimsIdentity);
                ClaimsPrincipal claimPrinsiple = new ClaimsPrincipal(claimsIdentities);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrinsiple);

                return Redirect("/Student");
            }


            return View("Index");
        }
    }
}
