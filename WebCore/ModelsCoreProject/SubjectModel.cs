using System;
using System.Collections.Generic;
using WebCoreEntities;
using System.Linq;
using UtilityCore;

namespace ModelsCoreProject
{
    public class SubjectModel : BaseModel
    {

     

        public string Id { get; set; }

         

        public string Name { get; set; }

        

        public string GetWhere()
        {
            string queryWhere = " Where 1=1  ";

            if (!string.IsNullOrWhiteSpace(Id))
            {
                queryWhere += "  and ts.id =" + Id.Replace("'", "''");
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryWhere += "  and ts.Name like '%" + Name.Replace("'","''") + "%'";
            }
            return queryWhere;
        }




        public IEnumerable<Subject> GetWhere(IEnumerable<Subject> lstSubject)
        {

             if (!string.IsNullOrWhiteSpace(Id))
            {
                lstSubject = lstSubject.Where(X => X.Id == Id.Converts<int>());
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                lstSubject = lstSubject.Where(X => X.Name.Contains(Name));
            }
            return lstSubject;
        }

    }
}
