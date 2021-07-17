using ModelsCoreProject;
using System.Collections.Generic;
using WebCoreEntities;

namespace WebCoreRepositoryLayer
{
    public interface IStudentRepository
    {
        
        List<Student> GetAllStudent(StudentModel studentModel);
        Student GetStudentById(int id);
        Student SaveStudent(Student student);
        int DeleteStudent(int id);
    }
}