using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;
using Unosquare.RaspberryIO.Native;

namespace I2C_Communicator
{



    public class Communicator
    {
        private const int _MyID = 1;

        public I2CDevice myDevice;

        public List<I2CDevice> AvailableDevices;

        public Communicator()
        {
            Console.WriteLine("Enter Comminicator");

            myDevice = Pi.I2C.AddDevice(0x40);

            this.AvailableDevices = this.GetDevices();

            Console.WriteLine("Exit Constructor");
        }
        
        private List<I2CDevice> GetDevices()
        {
            Console.WriteLine("Enter Get Devices");

            List<I2CDevice> list = new List<I2CDevice>();

            foreach (var device in Pi.I2C.Devices)
            {
                Console.WriteLine("Add Device" + device.DeviceId.ToString("{0:X}"));
                list.Add(device);
            }

            Console.WriteLine("ExitGetDevices");
            return list;
        }

        public int GetNumSensors(I2CDevice device)
        {
            device.Write(0x01);
            int numSensors = device.Read();

            return numSensors;
         }



        public Dictionary<int, Dictionary<string, float>> GetTemps()
        {

            Console.WriteLine("Enter GetAddresses");
            Dictionary<int, Dictionary<string, float>> lookup = new Dictionary<int, Dictionary<string, float>>();
            
            foreach (var device in Pi.I2C.Devices)
            {
                var list = new Dictionary<string, float>();

                //Console.WriteLine("Request Num of Sensors From " + device.DeviceId.ToString());

                //device.Write(0x01);

                //Console.WriteLine("Get Number of Sensors");
                //int numSensors = device.Read();

                int numSensors = this.GetNumSensors(device);

                device.Write(0x02);

                int expectedData = numSensors * 8 + 1 + numSensors * 4;

                byte[] data = device.Read(expectedData);


                //Console.WriteLine("Reading " + (numSensors * 8 + 1) + " Bytes");
                //var addressData = device.Read(numSensors * 8 + 1);
                //Console.WriteLine("Read " + addressData.Length + " Bytes");

                //Update number of sensors
                if (data.Length != expectedData)
                {
                    return null;
                    //numSensors = (int)addressData[0];

                }


                //if (addressData.Length != (numSensors * 8 + 1))
                //{
                //    Console.WriteLine("Returning null");
                //    Console.WriteLine(addressData.Length + "  " + (numSensors * 8 + 1));
                //    return null;
                //}

                int i = 1;
                while ( i < data.Length)
                {
                    var address = new byte[8];
                    var rawTemp = new byte[4];
                    for (uint j =0; j < 8; j++)
                    {
                        address[j] = data[i];
                        i++;
                    }
                    for (uint j =0; j < 4; j++)
                    {
                        rawTemp[j] = data[i];
                        i++;
                    }

                    string address_str = getAddressString(address);
                    float temp = BitConverter.ToSingle(rawTemp, 0);

                    Console.WriteLine("Saving Address: " + getAddressString(address));
                    list[address_str] = temp;
                }

                

                lookup[device.DeviceId] = list;
            }

            return lookup;
        }

        //public Dictionary<string, double> GetTemps()
        //{
        //    Dictionary<string, double> lookup = new Dictionary<string, double>();

        //    var addresses = this.GetAddresses();

            

        //    Thread.Sleep(200);
        //    foreach (var device in Pi.I2C.Devices)
        //    {
        //        if (addresses != null && addresses.ContainsKey(device.DeviceId))
        //        {
        //            foreach (var address in addresses[device.DeviceId].Select((value, idx)=>new { value, idx }))
        //            {
        //                List<byte> command = new List<byte>();


        //                command.Add(0x03);
        //                //foreach (var _byte in address) { command.Add(_byte); }

        //                Console.WriteLine("Index: " + address.idx);
        //                Console.WriteLine("AsByte: " + Convert.ToByte(address.idx));
        //                command.Add(Convert.ToByte(address.idx));

        //                try
        //                {
        //                    Console.WriteLine("Writing Array to Arduino");
        //                    device.Write(command.ToArray());
        //                }
        //                catch (HardwareException e)
        //                {
        //                    Console.WriteLine(e.Component);
        //                    if (e.ExtendedMessage != null)
        //                        Console.WriteLine(e.ExtendedMessage);
        //                }
        //                Console.WriteLine("Reading Bytes from Arduino");
        //                byte[] data = device.Read(12);

        //                if (data.Length != 12)
        //                    return null;

        //                var recievedAddress = getAddressString(data.Take(8).ToArray());

        //                Console.WriteLine("Recieved Address: " + recievedAddress);
        //                float temp = (BitConverter.ToSingle(data,8));

        //                //Console.WriteLine("Recieved Float: " + data_float);

        //                //double temp = ;

        //                Console.WriteLine("Float: " + temp);


        //                if (recievedAddress.Equals(address.value))
        //                    lookup[getAddressString(address.value)] = temp;
        //                else
        //                    Console.WriteLine("Address Missmatch");
        //            }
        //        }
        //    }

        //    return lookup;
        //}

        private static string getAddressString(byte[] address)
        {
            StringBuilder hex = new StringBuilder(address.Length * 2 + 2);

            hex.Append("0x");

            foreach (byte b in address)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }
    }
}
