using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Sensors.TemperatureSensors
{
    public class TemperatureSensor : ISensor
    {
        [Key]
        public string Address { get; set; }

        public string Name { get; set; }

        
    }
}
