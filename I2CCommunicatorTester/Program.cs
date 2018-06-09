using I2C_Communicator;
using System;
using System.Text;
using System.Threading;

namespace I2CCommunicatorTester
{
    class Program
    {
        private static Communicator communicator;

        static void Main(string[] args)
        {
            communicator = new Communicator();

            int i = 0;

            while(i == 0)
            {
                Thread.Sleep(5000);

                var tempLookup = communicator.GetTemps();//.GetAddresses();

                Console.WriteLine("Available Sensors:");


                int j = 0;
                foreach(var device in tempLookup.Keys)
                {
                    foreach (var address in tempLookup[device].Keys)
                    {
                        Console.WriteLine("Sensor " + j + ":");
                        Console.WriteLine("Address: " + address);
                        Console.WriteLine("Temperature: " + tempLookup[device][address]);
                        Console.WriteLine();
                        j++;
                    }
                    
                }
            }


            

        }

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
