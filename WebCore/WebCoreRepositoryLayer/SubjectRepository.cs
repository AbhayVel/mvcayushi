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
    public class SubjectRepository 
    {

        string _subjectAllQuery = "Select Id, Name  From dbo.TblSubject as ts ";
        string _subjectAllCountQuery = "Select Count(1) as Count From dbo.TblSubject as ts ";
        public StudentMSContext StudentMSContext { get; set; }

        public SubjectRepository()
        {
            StudentMSContext = new StudentMSContext();
        }


        public void SetSubject<T>(List<T> lst) where T : ISubject
        {
            List<int> lstSubjectInt = lst.Where(x => x.SubjectId.HasValue).Select(x => x.SubjectId.Value).Distinct().ToList<int>();

            List<Subject> lstSubject = StudentMSContext.SubjectSet.Where(x => lstSubjectInt.Contains(x.Id)).ToList();
            foreach (var item in lst)
            {
                if (item.SubjectId.HasValue && item.SubjectId.Value > 0)
                {
                    item.Subject = lstSubject.FirstOrDefault(x => x.Id == item.SubjectId.Value);
                }
            }
        }


        public int GetAllSubjetCount(SubjectModel subjectModel)
        {

            string query = _subjectAllCountQuery + subjectModel.GetWhere();
            int count = StudentMSContext.CountByRawSql(query);
            return count;
        }


        public List<Subject> GetAllSubjet(SubjectModel subjectModel)
        {
            int count = GetAllSubjetCount(subjectModel);
            string query = _subjectAllQuery + subjectModel.GetWhere() + subjectModel.GetOrderBy() + subjectModel.Pagination.SetPageQuery(count);
            List<Subject> lst = StudentMSContext.SubjectSet.FromSqlRaw(query).ToList<Subject>();
            return lst;
        }

        public List<Subject> GetAllSubjet()
        {
            string query = _subjectAllQuery;
            List<Subject> lst = StudentMSContext.SubjectSet.FromSqlRaw(query).ToList<Subject>();
            return lst;
        }

        public Subject GetStudentById(int id)
        {
            var subject = StudentMSContext.SubjectSet.FirstOrDefault(x => x.Id == id);
            return subject;
        }
    }

}
