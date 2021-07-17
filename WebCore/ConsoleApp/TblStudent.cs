using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleApp
{

    [Table(name: "TblStudent")]
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SubjectId { get; set; }
        public decimal Age { get; set; }
        public decimal? Fees { get; set; }
        public bool? Active { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
