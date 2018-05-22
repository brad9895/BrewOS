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
        public string SensorID { get; set; }
    }
}
