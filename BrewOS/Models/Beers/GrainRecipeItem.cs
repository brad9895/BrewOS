using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Beers
{
    public class GrainRecipeItem
    {
        [Key]
        public int ID { get; set; }
        public Grain grain { get; set; }

        public double Amount { get; set; }
    }
}
