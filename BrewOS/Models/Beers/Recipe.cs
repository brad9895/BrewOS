using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Beers
{
    public class Recipe
    {
        [Key]
        public string RecipeName { get; set; }


    }
}
