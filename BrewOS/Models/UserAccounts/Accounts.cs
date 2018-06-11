using BrewOS.Data;
using BrewOS.Models.UserAccounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models
{

    // Singleton

    public class Accounts
    {
        private List<User> Users = null;


        private Accounts()
        {
            //var x = BrewOSContext.Instance;

            //Users = x.Accounts.Include(y => y.ContactInfo)
            //    .Include(y => y.PermissionSet).ToList();

            
        }

        private static Accounts _Instance;

        public static Accounts Instance
        {
            get
            {
                return _Instance != null ? _Instance : createInstance();
            }
        }

        private static Accounts createInstance()
        {
            _Instance = new Accounts();
            return _Instance;
        }

    }
}
