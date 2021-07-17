using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebCoreEntities
{

    public class MyValidtor: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string str = value.ToString();
            return true;
        }
    }

    [Table(name: "TblStudent")]
    public class Student : ISubject
    {
        public int Id { get; set; } //<-Property

        [Display(Name ="First Name")]
        [Required]
       [RegularExpression("[A-Za-z]{1,10}", ErrorMessage ="Please entery propery First Name")]

      [MaxLength(10)]
        public string FirstName { get; set; }



        [MyValidtor]
        public string LastName { get; set; }

      

        public int? SubjectId { get; set; }

        public decimal Age { get; set; }
        public decimal? Fees { get; set; }
        public bool? Active { get; set; }

        public virtual Subject Subject { get; set; }



    }
}
