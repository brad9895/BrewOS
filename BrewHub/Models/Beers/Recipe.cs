﻿using System;
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

        public string StyleName { get; set; }
        public BeerStyle Style { get; set; }

        public double TargetGravity { get; set; }
        public double MashingTemp { get; set; }
        

        public List<Grain> GrainBill { get; set; } 
    }
}
