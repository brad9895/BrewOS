using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Beers
{
    public class BeerStyle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string StyleName { get; set; }

        public string StyleDescription { get; set; }
        public string StyleImage { get; set; }
    }
}
