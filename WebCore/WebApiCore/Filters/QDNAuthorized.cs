using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebCore.Filters
{

    public static class HttpContextExtension
    {

        public static bool IsInRoleCheck(this ClaimsPrincipal claimsPrincipal,string claims)
        {
           List<string> lst= claims.Split(',').Select(x => x.Trim().ToLower()).ToList();

            if (lst.Count != 2)
            {
                return false;
            }

          Claim c=  claimsPrincipal.FindFirst(x => x.Type.ToLower().Equals(lst[0]));
            try
            {
                if (c!=null && c.Value.ToLower().Contains(lst[1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
           
          
        }

    } 

    public class QDNAuthorized : Attribute, IAuthorizationFilter
    {
        public string ClaimList { get; set; }
        public string Role { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ClaimsPrincipal claimsPrincipal = context.HttpContext.User;
           if(claimsPrincipal.IsInRoleCheck(ClaimList))
            {

            } else
            {
                context.Result = new RedirectResult("/Unauth/index");
            }
        }
    }
}
