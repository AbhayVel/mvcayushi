using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreEntities;
using WebCoreServiceLayer;

namespace WebCore.ViewComponents
{
    public class SubjectIdViewComponent : ViewComponent
    {
        public SubjectService SubjectService { get; set; }
        public SubjectIdViewComponent(SubjectService subjectService)
        {
            SubjectService = subjectService;
        }

        public   ViewViewComponentResult Invoke(ISubject isubject)
        {
            List<Subject> lstSubject = SubjectService.GetAllSubjet();
            lstSubject.Insert(0,new Subject
            {
                Id = 0,
                Name = "--Select--"
            });
            ViewBag.subjects = lstSubject;// new SelectList(lstSubject, "id", "Name", student.SubjectId);

            return View(isubject);
        }

    }
}
