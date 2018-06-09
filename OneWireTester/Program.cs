using OneWire;
using System;
using System.Linq;

namespace OneWireTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = OneWireBus.Instance;

            bus.DeviceAdded += BindDevice;

            foreach (var device in bus.Devices.Where(x => x.Type == DeviceType.DS18B20).Select(x => x as TempSensorDS18B20))
            {
                device.TemperatureUpdated += Device_TemperatureUpdated;
            }


            while(true)
            {

            }
        }

        private static void Device_TemperatureUpdated(object sender, EventArgs e)
        {
            var device = sender as TempSensorDS18B20;

            Console.WriteLine("Address: " + device.Address);
            Console.WriteLine("Temperature: " + device.TempF + "°F\r\n");
        }

        private static void BindDevice(object sender, DeviceAddedEvent e)
        {
            (e.Device as TempSensorDS18B20).TemperatureUpdated += Device_TemperatureUpdated;
            
        }
    }
}
