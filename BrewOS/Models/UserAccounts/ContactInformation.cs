using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Device.Location;
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
        
        [ForeignKey("AddressLine1,City,StateProvince,PostalCode")]
        public CivicAddress Address { get; set; }

        public ContactInformation()
        {
           
        }
        
    }
}
