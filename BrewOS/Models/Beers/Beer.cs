using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Beers
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerID { get; set; }

        public string RecipeName { get; set; }
        public Recipe _Recipe { get; set; }

        public double ABV { get; set; }
        
        public double InitalGravity { get; set; }
        public double FinalGravity { get; set; }

        public string Description { get; set; }
    }
}
