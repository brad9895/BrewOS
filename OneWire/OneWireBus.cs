using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OneWire
{
    public class OneWireBus
    {
        private const string _OneWireDir = "//sys//bus//w1//devices";

        private static OneWireBus _Instance = null;
        public static OneWireBus Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new OneWireBus();
                return _Instance;
            }
        }

        public event EventHandler<DeviceAddedEvent> DeviceAdded;

        private OneWireDeviceFactory _Factory = OneWireDeviceFactory.Instance;

        public List<OneWireDevice> _Devices = new List<OneWireDevice>();
        public List<OneWireDevice> Devices { get { return this._Devices; }}

        private OneWireBus()
        {
            this.readLoopAsync();
        }

        private async void readLoopAsync()
        {
           await Task.Run(() => readLoop());
        }

        private void readLoop()
        {
            while (true)
            {
                this.readSensors();


                Thread.Sleep(2000);
            }
        }

        private List<string> readSensors()
        {
            if (Directory.Exists(_OneWireDir))
            {
                var addresses = Directory.GetDirectories(_OneWireDir).Select(x => Path.GetFileName(x))
                    .Where(x => !x.Equals("w1_bus_master1"));


                //Console.WriteLine("Found Sensors:");
                foreach (var address in addresses)
                {
                    if (!this._Devices.Where(x => x.Address.Equals(address)).Any())
                    {
                        var device = _Factory.CreateDevice(address);
                        this._Devices.Add(device);
                        this.DeviceAddedToBus(device);
                    }
                }

                foreach (var device in this._Devices)
                {
                    device.UpdateReading();

                   // Console.WriteLine("Address: " + device.Address);

                    //if (device.Type == DeviceType.DS18B20)
                    //    Console.WriteLine("Temperature: " + (device as TempSensorDS18B20).TempF + "°F\r\n");

                    

                }

            }

            return null;
        }

        private void DeviceAddedToBus(OneWireDevice device)
        {
            if (DeviceAdded != null)
                DeviceAdded(this, new DeviceAddedEvent(device));
        }
    }

    public class DeviceAddedEvent : EventArgs
    {
        public OneWireDevice Device;

        public DeviceAddedEvent(OneWireDevice device)
        {
            this.Device = device;
        }
    }
}
