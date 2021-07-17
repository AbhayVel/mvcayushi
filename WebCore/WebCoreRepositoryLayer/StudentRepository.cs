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
    public class StudentRepository : IStudentRepository
    {

        string _studentAllQuery = "Select s.Id,S.FirstName, s.LastName, s.Age, S.subjectId as subjectId, s.fees as fees,s.Active, ts.Name as [Subject.Name], ts.Id as [Subject.Id] From dbo.TblStudent as s Left Join [dbo].[TblSubject] ts  on s.SubjectId=ts.Id";
        string _studentAllCountQuery = "Select Count(1) as Count From dbo.TblStudent as s Left Join [dbo].[TblSubject] ts  on s.SubjectId=ts.Id";
        public StudentMSContext StudentMSContext { get; set; }

        public StudentRepository()
        {
            StudentMSContext = new StudentMSContext();
        }


        public int GetAllStudentCount(StudentModel studentModel)
        {

            string query = _studentAllCountQuery + studentModel.GetWhere();
            int count = StudentMSContext.CountByRawSql(query);
            return count;
        }


         

        public List<Student> GetAllStudent()
        {
            List<Student> lst = StudentMSContext.StudentSet.FromSqlRaw(_studentAllQuery).ToList<Student>();             
            return lst;
        }


        public Student GetStudent(Dictionary<string,string> dict)
        {
            var student = new Student();
            UtilityCore.Binders.MyModelBinder(student, dict, false);
            return student;
        }

        public List<Student> GetAllStudent(StudentModel studentModel)
        {
            int count = GetAllStudentCount(studentModel);
            string query = _studentAllQuery + studentModel.GetWhere() + studentModel.GetOrderBy() + studentModel.Pagination.SetPageQuery(count);
            var data = StudentMSContext.ObjectDictionaryByRawSql(query);
            var lstData=  data.Select(X => GetStudent(X)).ToList();
            List<Student> lst = StudentMSContext.StudentSet.FromSqlRaw(query).ToList<Student>();
           
            return lst;
        }
        
        public Student GetStudentById(int id)
        {
            var student = StudentMSContext.StudentSet.FirstOrDefault(x => x.Id == id);
            return student;
        }

        public Student SaveStudent(Student student)
        {
            if (student.Id == 0)
            {
                this.StudentMSContext.StudentSet.Add(student);
                this.StudentMSContext.SaveChanges();
            } else
            {
                this.StudentMSContext.StudentSet.Attach(student);
                this.StudentMSContext.Entry(student).State = EntityState.Modified;
                this.StudentMSContext.SaveChanges();
            }

            return student;
        }

        public int DeleteStudent(int id)
        {
          var Student=  this.StudentMSContext.StudentSet.FirstOrDefault(x => x.Id == id);
            if (Student != null)
            {
                this.StudentMSContext.StudentSet.Remove(Student);
                this.StudentMSContext.SaveChanges();
                return 1;
            }
            else
            {
                return -1;
            }
            
        }
    }

}
