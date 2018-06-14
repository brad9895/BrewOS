using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrewOS.Data;
using BrewOS.Hubs;
using BrewOS.Models.Sensors.TemperatureSensors;
using Microsoft.AspNetCore.Mvc;
using OneWire;

namespace BrewOS.Controllers
{
    public class SettingsController : Controller
    {

        private readonly BrewOSContext _context;

        private OneWireBus Bus = OneWireBus.Instance;

        public SettingsController(BrewOSContext context, TemperatueHubService hubService)
        {
            _context = context;

            //Bus.DeviceAdded += Bus_DeviceAdded;

            
        }

        private void Device_TemperatureUpdated(object sender, EventArgs e)
        {
            var device = sender as TempSensorDS18B20;

            Console.WriteLine("Address: " + device.Address);
            Console.WriteLine("Temperature: " + device.TempF + "°F\r\n");
         }

        private void Bus_DeviceAdded(object sender, DeviceAddedEvent e)
        {
            (e.Device as TempSensorDS18B20).TemperatureUpdated += Device_TemperatureUpdated;
        }

        

        public async Task<IActionResult> Index()
        {

            

            List<TemperatureSensor> list = await _context.GetKnownSensors();




            lock (Bus.DeviceLock)
            {
                foreach (var sensor in Bus.Devices
                    .Where(x => x.Type == DeviceType.DS18B20)
                    .Select(x => x as TempSensorDS18B20))
                {
                    var foundSensors = list.Where(x => x.Address.Equals(sensor.Address));

                    if (foundSensors.Any())
                    {
                        foundSensors.First().Sensor = sensor;
                    }
                    else
                    {
                        list.Add(new TemperatureSensor(sensor));
                    }
                }

                foreach ( var sensor in list.Select(x => x.Sensor))
                {
                    if (!Bus.Devices.Select(x => x.Address).Contains(sensor.Address))
                        sensor.UpdateReading();
                }
                
            }

            return View(list); ;
        }


        //protected override void Dispose(bool disposing)
        //{
        //    Console.WriteLine("Disposing");
        //
        //    base.Dispose(disposing);
        //}
    }
}