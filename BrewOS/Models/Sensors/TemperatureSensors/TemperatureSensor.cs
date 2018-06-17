using OneWire;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Sensors.TemperatureSensors
{
    public class TemperatureSensor : ISensor
    {
        
        [Key]
        public string Address { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public TempSensorDS18B20 Sensor { get; set; } 
        
        public TemperatureSensor()
        {
            Sensor = new TempSensorDS18B20();
        }
        public TemperatureSensor(TempSensorDS18B20 sensor)
        {
            this.Address = sensor.Address;
            this.Sensor = sensor;
        }
        
    }
}
