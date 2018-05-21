using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.UserAccounts
{
    public class User
    {
        public int UserID { get; set; }
        public ContactInformation ContactInfo { get; set; }


        public UserPermissions PermissionSet { get; set; }
    }
}
