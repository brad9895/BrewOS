using System;
using System.Collections.Generic;
using System.Text;

namespace OneWire
{
    class OneWireDeviceFactory
    {
        private static OneWireDeviceFactory _Instance = null;
        public static OneWireDeviceFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new OneWireDeviceFactory();

                return _Instance;
            }
        }

        private OneWireDeviceFactory()
        {

        }

        public OneWireDevice CreateDevice(string address)
        {
            //Console.WriteLine("Address: " + address);
            string devicetype = address.Substring(0, 2);

            OneWireDevice device = null;

            //Console.WriteLine("Device Type: " + devicetype);

            switch (devicetype)
            {
                case "28":
                    device = new TempSensorDS18B20(address);
                    break;
            }

            return device;

        }

    }
}
