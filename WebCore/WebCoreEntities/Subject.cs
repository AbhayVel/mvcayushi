using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreEntities
{
    [Table(name: "TblSubject")]
    public partial class Subject
    {
        public Subject()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}