using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsCoreProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using UtilityCore;
using WebApiCore.Filters;
using WebCore.Filters;
using WebCoreEntities;
using WebCoreServiceLayer;

namespace WebApiCore.Controllers
{

    [ApiVersion("1")]
    [ApiVersion("2")]
    [Authorize]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
   // [Produces(MediaTypeNames.Application.Json)]
    
    public class StudentController : BaseController
    {
        public IStudentService StudentService { get; set; }

        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }



        

        //[Route("student/index")]


         




        [QDNAuthorized(ClaimList = "Student,R")]
        [HttpPost]
        [MapToApiVersion("1")]
        [Route("post")]
        [ProducesResponseType(typeof(StudentModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(StudentModel studentModel)
        {
                List<Student> lStudent = StudentService.GetAllStudent(studentModel);
                studentModel.Students = lStudent;
                return Ok(studentModel);
                         
        }

        [QDNAuthorized(ClaimList = "Student,R")]
        [MapToApiVersion("2")]
        [Route("post")]
        [HttpPost]
        [ProducesResponseType(typeof(StudentModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post2(StudentModel studentModel)
        {
            List<Student> lStudent = StudentService.GetAllStudent(studentModel);
            studentModel.Students = lStudent;
            return Ok(studentModel);

        }

    }
}
