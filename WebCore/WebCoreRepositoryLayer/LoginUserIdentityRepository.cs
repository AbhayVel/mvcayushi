using System;
using System.Collections.Generic;
using System.Text;
using WebCoreEntities;
using System.Linq;
using ModelsCoreProject;
using WebCoreDbContext;
using Microsoft.EntityFrameworkCore;

namespace WebCoreRepositoryLayer
{
    public class LoginUserIdentityRepository
    {

        string _LoginUserIdentityAllQuery = "Select Id, Name  From dbo.TblLoginUserIdentity as ts ";
        string _LoginUserIdentityAllCountQuery = "Select Count(1) as Count From dbo.TblLoginUserIdentity as ts ";
        public StudentMSContext StudentMSContext { get; set; }

        public LoginUserIdentityRepository(StudentMSContext studentMSContext)
        {
            StudentMSContext= studentMSContext;
        }


        //public void SetLoginUserIdentity<T>(List<T> lst) where T : ILoginUserIdentity
        //{
        //    List<int> lstLoginUserIdentityInt = lst.Where(x => x.LoginUserIdentityId.HasValue).Select(x => x.LoginUserIdentityId.Value).Distinct().ToList<int>();

        //    List<LoginUserIdentity> lstLoginUserIdentity = StudentMSContext.LoginUserIdentitySet.Where(x => lstLoginUserIdentityInt.Contains(x.Id)).ToList();
        //    foreach (var item in lst)
        //    {
        //        if (item.LoginUserIdentityId.HasValue && item.LoginUserIdentityId.Value > 0)
        //        {
        //            item.LoginUserIdentity = lstLoginUserIdentity.FirstOrDefault(x => x.Id == item.LoginUserIdentityId.Value);
        //        }
        //    }
        //}


        //public int GetAllSubjetCount(LoginUserIdentityModel LoginUserIdentityModel)
        //{

        //    string query = _LoginUserIdentityAllCountQuery + LoginUserIdentityModel.GetWhere();
        //    int count = StudentMSContext.CountByRawSql(query);
        //    return count;
        //}


        //public List<LoginUserIdentity> GetAllSubjet(LoginUserIdentityModel LoginUserIdentityModel)
        //{
        //    int count = GetAllSubjetCount(LoginUserIdentityModel);
        //    string query = _LoginUserIdentityAllQuery + LoginUserIdentityModel.GetWhere() + LoginUserIdentityModel.GetOrderBy() + LoginUserIdentityModel.Pagination.SetPageQuery(count);
        //    List<LoginUserIdentity> lst = StudentMSContext.LoginUserIdentitySet.FromSqlRaw(query).ToList<LoginUserIdentity>();
        //    return lst;
        //}

        //public List<LoginUserIdentity> GetAllSubjet()
        //{
        //    string query = _LoginUserIdentityAllQuery;
        //    List<LoginUserIdentity> lst = StudentMSContext.LoginUserIdentitySet.FromSqlRaw(query).ToList<LoginUserIdentity>();
        //    return lst;
        //}

        public LoginUserIdentity GetLoginUserIdentityByName(string Name)
        {
            var LoginUserIdentity = StudentMSContext.LoginUserIdentitySet.FirstOrDefault(x => x.Name == Name);
            if (LoginUserIdentity != null)
            {
                var LoginUserIdentityClaimList = StudentMSContext.LoginUserClaimIdentitySet.Where(x => x.LoginUserId == LoginUserIdentity.Id).ToList();

                LoginUserIdentity.LoginUserClaimIdentityList = LoginUserIdentityClaimList;
            }
           
            return LoginUserIdentity;
        }
    }

}
