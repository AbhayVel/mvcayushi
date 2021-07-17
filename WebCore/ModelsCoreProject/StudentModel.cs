using System;
using System.Collections.Generic;
using WebCoreEntities;
using System.Linq;
using UtilityCore;
using System.ComponentModel.DataAnnotations;

namespace ModelsCoreProject
{
    public class CheckNumberValidtor : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int o;
            string str = value==null ? "" : value.ToString();
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            if (int.TryParse(str,out o))
            {
                return true;
            }
            return false;
        }
    }
    public class StudentModel : BaseModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        [CheckNumberValidtor]
        public string AgeGte { get; set; }
        public string AgeLte { get; set; }

        public virtual List<Student> Students { get; set; }

        public string GetWhere()
        {

            string queryWhere = " Where 1=1  ";

            if (!string.IsNullOrWhiteSpace(Id))
            {
                queryWhere += "  and s.id =" + Id.Replace("'", "''");
            }

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                queryWhere += "  and s.FirstName like '%" + FirstName.Replace("'","''") + "%'";
            }

            if (!string.IsNullOrWhiteSpace(LastName))
            {
                queryWhere += "  and s.LastName like '%" + LastName.Replace("'", "''") + "%'";
            }

            if (!string.IsNullOrWhiteSpace(Age))
            {
                queryWhere += "  and s.Age =" + Age.Replace("'", "''") + " ";
            }

            if (!string.IsNullOrWhiteSpace(AgeGte))
            {
                queryWhere += "  and s.Age >=" + AgeGte.Replace("'", "''") + " ";
            }

            if (!string.IsNullOrWhiteSpace(AgeLte))
            {
                queryWhere += "  and s.Age <=" + AgeLte.Replace("'", "''") + " ";
            }




            return queryWhere;
        }
        public IEnumerable<Student> GetWhere(IEnumerable<Student> lstStudent)
        {

             if (!string.IsNullOrWhiteSpace(Id))
            {
                lstStudent= lstStudent.Where(X => X.Id == Id.Converts<int>());
            }

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                lstStudent = lstStudent.Where(X => X.FirstName.Contains(FirstName));
            }

            if (!string.IsNullOrWhiteSpace(LastName))
            {
                lstStudent = lstStudent.Where(X => X.LastName.Contains(LastName));
            }

            if (!string.IsNullOrWhiteSpace(Age))
            {
                lstStudent = lstStudent.Where(X => X.Age == Convert.ToInt32(Age));
            }

            if (!string.IsNullOrWhiteSpace(AgeGte))
            {
                lstStudent = lstStudent.Where(X => X.Age >= Convert.ToInt32(AgeGte));
            }

            if (!string.IsNullOrWhiteSpace(AgeLte))
            {
                lstStudent = lstStudent.Where(X => X.Age <= Convert.ToInt32(AgeLte));
            }



            return lstStudent;
        }

    }
}
