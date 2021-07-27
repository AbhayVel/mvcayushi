using ModelsCoreProject;
using System;
using System.Collections.Generic;
using System.Text;
using WebCoreEntities;
using WebCoreRepositoryLayer;

namespace WebCoreServiceLayer
{
    public class StudentService : IStudentService
    {
        public IStudentRepository StudentRepository { get; set; }
        public SubjectRepository SubjectRepository { get; set; }
        public TestSingoltoneLifeCycle TestSingoltoneLifeCycle;
        public TestScopedLifeCycle TestScopedLifeCycle;
        public TestTransientLfieCycle TransientLfieCycle;
        public StudentService(IStudentRepository studentRepository, SubjectRepository subjectRepository, LoginUserIdentityRepository loginUserIdentityRepository,
           TestSingoltoneLifeCycle testSingoltoneLifeCycle,
           TestScopedLifeCycle testScopedLifeCycle,
           TestTransientLfieCycle transientLfieCycle



             )
        {
            TestSingoltoneLifeCycle = testSingoltoneLifeCycle;
            TestScopedLifeCycle = testScopedLifeCycle;
            TransientLfieCycle = transientLfieCycle;
            testSingoltoneLifeCycle.Add();
            testScopedLifeCycle.Add();
            transientLfieCycle.Add();
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
        }
        public List<Student> GetAllStudent()
        {
            var lStudent = StudentRepository.GetAllStudent(null);
            SubjectRepository.SetSubject(lStudent);
            return lStudent;
        }

        public List<Student> GetAllStudent(string columnName, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                columnName = "id";
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = "asc";
            }
            var lStudent = StudentRepository.GetAllStudent(null);
            return lStudent;
        }



         

        public List<Student> GetAllStudent(StudentModel studentModel)
        {
            if (studentModel.Pagination == null)
            {
                studentModel.Pagination = new Pagination();
            }
            var lStudent = StudentRepository.GetAllStudent(studentModel);
            SubjectRepository.SetSubject(lStudent);
            return lStudent;
        }

        public Student GetStudentById(int id)
        {
            Student student = StudentRepository.GetStudentById(id);
            return student;
        }


        public Student SaveStudent(Student student)
        {
            student = StudentRepository.SaveStudent(student);
            return student;
        }

        public int DeleteStudent(int id)
        {
            return StudentRepository.DeleteStudent(id);
        }
    }
}
