using System;
using System.Collections.Generic;
using System.Text;
using WebCoreEntities;
using WebCoreRepositoryLayer;

namespace WebCoreServiceLayer
{
   public class SubjectService
    {
        public SubjectRepository SubjectRepository { get; set; }
        public SubjectService(SubjectRepository subjectRepository)
        {
            SubjectRepository = subjectRepository;
        }

        public List<Subject> GetAllSubjet()
        {
            return SubjectRepository.GetAllSubjet();
        }
    }
}
