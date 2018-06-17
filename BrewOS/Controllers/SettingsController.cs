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
    [Route("[controller]/[action]")]
    public class SettingsController : Controller
    {

        private readonly BrewOSContext _context;

        private OneWireBus Bus = OneWireBus.Instance;

        public SettingsController(BrewOSContext context, TemperatueHubService hubService)
        {
            _context = context;
            
        }

        //private void Device_TemperatureUpdated(object sender, EventArgs e)
        //{
        //    var device = sender as TempSensorDS18B20;

        //    Console.WriteLine("Address: " + device.Address);
        //    Console.WriteLine("Temperature: " + device.TempF + "°F\r\n");
        // }

        //private void Bus_DeviceAdded(object sender, DeviceAddedEvent e)
        //{
        //    (e.Device as TempSensorDS18B20).TemperatureUpdated += Device_TemperatureUpdated;
        //}
        
        [Route("[controller]/Index")]
        public async Task<IActionResult> Index()
        {

            List<TemperatureSensor> list = await _context.GetKnownSensors();
            //List<TemperatureSensor> list = new List<TemperatureSensor>();

            //list.Add(new TemperatureSensor());
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

                foreach (var sensor in list.Where(x => x.Sensor != null).Select(x => x.Sensor))
                {
                    if (!Bus.Devices.Select(x => x.Address).Contains(sensor.Address))
                        sensor.UpdateReading();
                }

            }

            //if (!list.Any())
            //{
            //    list.Add(new TemperatureSensor()
            //    {
            //        Address = "xxxx",
            //        Name  = "Name"
            //    });
            //    _context.Sensors.Add(list.First());
            //    await _context.SaveChangesAsync();
            //}

            return View(list);
        }

        // GET: Settings/Update/
        [Route("[controller]/Update/{id?}")]
        [HttpPost("{id?}")]
        public void Update(string id, TemperatureSensor _device)
        {
            //var x = Request.Form.["Address"];

            Console.WriteLine("Update " + _device.Address);


            

            //return View();
        }

        //public async Task<IActionResult> Delete(string id)
        //{
        //    Console.WriteLine("Delete " + id);

        //    return View();
        //}

    }
}