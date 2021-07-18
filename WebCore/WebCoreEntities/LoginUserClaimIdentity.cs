using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace WebCoreEntities
{

    [Table("TblLoginUserClaim")]
    public class LoginUserClaimIdentity 
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
        

        public string Value { get; set; }


        [ForeignKey("LoginUserIdentity")]
        public int LoginUserId { get; set; }

        public virtual LoginUserIdentity LoginUserIdentity { get; set; }

    }


}
