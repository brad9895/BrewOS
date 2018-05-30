using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Beers
{
    public class Grain
    {
        [Key]
        public string GrainType { get; set; }
        public double Amount { get; set; }

    }
}
