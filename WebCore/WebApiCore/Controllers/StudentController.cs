using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsCoreProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityCore;
using WebApiCore.Filters;
using WebCoreEntities;
using WebCoreServiceLayer;

namespace WebApiCore.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : BaseController
    {
        public IStudentService StudentService { get; set; }

        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }



        [HttpGet]
        public async Task<IActionResult> Index2(string columnName, string orderBy)
        {
            List<Student> lStudent = StudentService.GetAllStudent(columnName, orderBy);
            return Ok(lStudent);
        }

        //[Route("student/index")]
        [HttpGet]

        [AcceptVerbs(new string[] { "Get", "Post" })]
        public async Task<IActionResult> Index()
        {
            StudentModel studentModel = new StudentModel();
            List<Student> lStudent = StudentService.GetAllStudent(studentModel);
            studentModel.Students = lStudent;
            return Ok(studentModel);
        }


        int i = 0;
        [HttpPost]
        public async Task<IActionResult> Post(StudentModel studentModel)
        {
            
            try
            {
                List<Student> lStudent = StudentService.GetAllStudent(studentModel);
                studentModel.Students = lStudent;
                return Ok(studentModel);
            }
            catch (Exception ex)
            {
                throw new Exception("User required to update Data");
            }               
        }

    }
}
