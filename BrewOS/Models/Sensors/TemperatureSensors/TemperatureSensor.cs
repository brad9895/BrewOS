using OneWire;
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
        public TempSensorDS18B20 Sensor { get; set; } 

        public string Name { get; set; }
        
        
        public TemperatureSensor()
        {

        }
        public TemperatureSensor(TempSensorDS18B20 sensor)
        {
            this.Address = sensor.Address;
            this.Sensor = sensor;
        }
        
    }
}
