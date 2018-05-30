using System.ComponentModel.DataAnnotations;

namespace BrewOS.Models.UserAccounts
{
    public class ContactInformation
    {
        [Key]
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }
        
        public string   Address { get; set; }
        public string   City { get; set; }
        public string   StateProvince { get; set; }
        public int      PostalCode { get; set; }

        public ContactInformation()
        {
           
        }
        
    }
}
