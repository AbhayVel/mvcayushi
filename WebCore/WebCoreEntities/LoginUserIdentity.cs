using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace WebCoreEntities
{


    [Serializable]

    [Table("TblLoginUser")]
    public class LoginUserIdentity : IIdentity
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        [NotMapped]
        public string AuthenticationType { get; set; }


        [NotMapped]
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }


        [JsonIgnore]
       [NotMapped]
        public virtual List<LoginUserClaimIdentity> LoginUserClaimIdentityList { get; set; }

    }


}
