using System;
using System.Collections.Generic;
using System.Text;

namespace WebCoreEntities
{
   public interface ISubject
    {
        int? SubjectId { get; set; }
        Subject Subject { get; set; }
    }
}
