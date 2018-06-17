using BrewOS.Models.Beers;
using BrewOS.Models.Sensors.TemperatureSensors;
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

        public string Address { get; set; }
        public TemperatureSensor TempSensor { get; set; }

    }
}
