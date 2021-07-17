using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreEntities
{
    [Table(name: "TblDepartment")]
    public partial class Department : ISubject
    {
        public Department()
        {
             
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}