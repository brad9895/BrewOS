using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.UserAccounts
{
    public class ContactInformation
    {
        [Key]
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }
        //[ForeignKey("AreaCode,Prefix,Extension")]
        //public PhoneNumber Phone { get; set; }
        public string Address { get; set; }

        public ContactInformation()
        {

        }
        
    }
}
