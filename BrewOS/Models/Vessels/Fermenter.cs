using BrewOS.Models.Beers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Vessels
{
    public class Fermenter
    {
        [Key]
        public string Name { get; set; }
        public double TargetTemp { get; set; }

        public int BeerID { get; set; }
        public Beer Wort { get; set; }


    }
}
