using BrewOS.Models.Beers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Vessels
{
    public class Dispenser
    {
        [Key]
        public int DispenserID { get; set; }

        public int BeerID { get; set; }
        public Beer OnTap { get; set; }

    }
}
