using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelsCoreProject;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore;
using WebApiCore.Filters;
using WebCoreEntities;
using WebCoreServiceLayer;

namespace WebApiCore.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginUserIdentityService LoginUserIdentityService { get; set; }

        public LoginController(LoginUserIdentityService loginUserIdentityService)
        {
            LoginUserIdentityService = loginUserIdentityService;
        }



        

        


        [HttpPost]
        public async Task<string> Login(LoginUserIdentity loginUserIdentity)
        {

        var claimsIdentity =    LoginUserIdentityService.GetClaimsIdentitiesByName(loginUserIdentity.Name, loginUserIdentity.Password);
         var std = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("123456789101234578")),
                     SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(1)
            };
            var jwt = new JwtSecurityTokenHandler();
            var token=    jwt.CreateToken(std);
            var jsonString = jwt.WriteToken(token);
            return jsonString;
        }

    }
}
