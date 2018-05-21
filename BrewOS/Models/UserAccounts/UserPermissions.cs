using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.UserAccounts
{
    public class UserPermissions
    {
        [Key]
        public String PermissionSetID { set; get; }
    }
}
