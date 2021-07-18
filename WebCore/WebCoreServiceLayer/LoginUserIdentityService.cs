using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WebCoreConstants;
using WebCoreEntities;
using WebCoreRepositoryLayer;

namespace WebCoreServiceLayer
{
   public class LoginUserIdentityService
    {
        public LoginUserIdentityRepository LoginUserIdentityRepository { get; set; }
        public LoginUserIdentityService(LoginUserIdentityRepository loginUserIdentityRepository)
        {
            LoginUserIdentityRepository = loginUserIdentityRepository;
        }

        public  LoginUserIdentity GetLoginUserIdentityByName(string name)
        {
            return LoginUserIdentityRepository.GetLoginUserIdentityByName(name);
        }



        public LoginUserIdentity GetLoginUserIdentityByName(string name, string password)
        {
            LoginUserIdentity loginUser = LoginUserIdentityRepository.GetLoginUserIdentityByName(name);
            if (loginUser == null || !loginUser.Password.Equals(password))
            {
                return null;
            }
            
            return loginUser;
        }

        public ClaimsIdentity GetClaimsIdentitiesByName(string name, string password)
        {
            LoginUserIdentity loginUser = LoginUserIdentityRepository.GetLoginUserIdentityByName(name);
            if (loginUser == null || !loginUser.Password.Equals(password))
            {
                return null;
            }
            loginUser.IsAuthenticated = true;
            loginUser.AuthenticationType = Constants.AuthCookieScheama;
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
            foreach (var item in loginUser.LoginUserClaimIdentityList)
            {
                claimsIdentity.AddClaim(new Claim(item.Type, item.Value));
            }            
            return claimsIdentity;
        }




        public ClaimsPrincipal GetClaimsPrincipal(LoginUserIdentity loginUser)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
            foreach (var item in loginUser.LoginUserClaimIdentityList)
            {
                claimsIdentity.AddClaim(new Claim(item.Type, item.Value));
            }
            List<ClaimsIdentity> claimsIdentities = new List<ClaimsIdentity>();
            claimsIdentities.Add(claimsIdentity);
            ClaimsPrincipal claimPrinsiple = new ClaimsPrincipal(claimsIdentities);
            return claimPrinsiple;
        }

        public ClaimsPrincipal GetClaimsPrincipalByName(string name,string password)
        {
            LoginUserIdentity loginUser = LoginUserIdentityRepository.GetLoginUserIdentityByName(name);
            if (loginUser == null  || !loginUser.Password.Equals(password))
            {
                return null;
            }            
            loginUser.IsAuthenticated = true;
            loginUser.AuthenticationType = Constants.AuthCookieScheama;
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
            foreach (var item in loginUser.LoginUserClaimIdentityList)
            {
                claimsIdentity.AddClaim(new Claim(item.Type, item.Value));
            }
            List<ClaimsIdentity> claimsIdentities = new List<ClaimsIdentity>();
            claimsIdentities.Add(claimsIdentity);
            ClaimsPrincipal claimPrinsiple = new ClaimsPrincipal(claimsIdentities);
            return claimPrinsiple;
        }
   
    
    
    }
}
