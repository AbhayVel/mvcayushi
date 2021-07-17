using ModelsCoreProject;
using System.Collections.Generic;
using WebCoreEntities;
using WebCoreRepositoryLayer;

namespace WebCoreServiceLayer
{
    public interface IStudentService
    {
        IStudentRepository StudentRepository { get; set; }

        List<Student> GetAllStudent();


        List<Student> GetAllStudent(string columnName, string orderBy);
        List<Student> GetAllStudent(StudentModel studentModel);
        Student GetStudentById(int id);

        Student SaveStudent(Student student);
        int DeleteStudent(int id);
    }
}