using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsCoreProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UtilityCore;
using WebApiCore.Filters;
using WebCore.Filters;
using WebCoreEntities;
using WebCoreServiceLayer;

namespace WebCore.Controllers
{




     
   
    [QdnActionFilter]
    [QdnExceptionFilterAttribute]
    //Name +COnroller 
    public class StudentController : Controller
    {

        public IStudentService StudentService { get; set; }

       

        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }


        int i = 0;

        [QDNAuthorized(ClaimList = "Student,R")]
        public IActionResult Index(StudentModel studentModel, Pagination pagination)
        { 
            
            studentModel.Pagination = pagination;
            List<Student> lStudent = StudentService.GetAllStudent(studentModel);

            ViewBag.studentModel = studentModel;
            ViewBag.orderBy = studentModel.OrderBy;
            ViewBag.columnName = studentModel.ColumnName;
            ViewBag.pagination = pagination;
            return View("Index", lStudent);
        }


        //public IActionResult Index(StudentModel studentModel)
        //{

        //    List<Student> lStudent = StudentService.GetAllStudent(studentModel);

        //    if (string.IsNullOrWhiteSpace(orderBy))
        //    {
        //        ViewBag.orderBy = studentModel.OrderBy;
        //    }
        //    else if (orderBy.ToLower().Equals("desc"))
        //    {
        //        ViewBag.orderBy = "asc";
        //    }
        //    else
        //    {
        //        ViewBag.orderBy = "desc";
        //    }

        //    return View(lStudent);
        //}



        [QDNAuthorized(ClaimList = "Student,A")]
        public IActionResult Add()
        {
            Student student = new Student();
            return View("Edit",student);
        }



        [QDNAuthorized(ClaimList = "Student,E")]
        public IActionResult Edit(int id)
        {
          Student student  = StudentService.GetStudentById(id);
          return View(student);
        }



        
        [QDNAuthorized(ClaimList = "Student,A")]


        [HttpPost]
        public IActionResult Save(Student student)
        {
          // var d=    ModelState.Values.FirstOrDefault(X => X.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid);
            if (ModelState.IsValid)
            {
                StudentService.SaveStudent(student);
                return Redirect("/student/index");
            } else
            {
               return View("Edit", student);
            }
           
        }


        [QDNAuthorized(ClaimList = "Student,D")]
        public IActionResult Delete(int id)
        {
            StudentService.DeleteStudent(id);
            return Redirect("/student/index");
        }



            public IActionResult Check()
        {

            return View();
        }
    }
}
