using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneWire
{
    

    public class TempSensorDS18B20 : OneWireDevice
    {

        private object tempCLock = new object();
        
        private double _TempC;
        

        public double TempC
        {
            get
            {
                lock (tempCLock)
                {
                    return this._TempC;
                }
            }
            private set
            {
                lock (tempCLock)
                {
                    this._TempC = value;
                    this.NotifyPropertyChanged("TempC");
                    this.TempUpdated();
                }
            }
        }
        public double TempF { get { return Utilities.ConvertTemp.ConvertCelsiusToFahrenheit(this.TempC); } }

        public event EventHandler TemperatureUpdated;

        public TempSensorDS18B20() : base(DeviceType.DS18B20)
        {

        }

        public TempSensorDS18B20(string address) : base(DeviceType.DS18B20)
        {
            this.Address = address;
        }

        public override bool UpdateReading()
        {
            if (base.UpdateReading())
            {
                //Console.WriteLine("Sensor Data:");

                //foreach (var line in _RawData)
                //{
                //    Console.WriteLine(line);
                //}

                if (this._RawData.Any() && this._RawData.ElementAt(0).Contains("YES") && this._RawData.Count == 2)
                {
                    int tempIndex = this._RawData.ElementAt(1).IndexOf('t');

                    if (tempIndex == -1)
                    {
                        //Console.WriteLine("Bad Index");
                        return false;
                    }

                    int outValue = int.MinValue;

                    bool success =  int.TryParse(this._RawData.ElementAt(1).Substring(tempIndex + 2), out outValue);

                    if (!success)
                    {
                        //Console.WriteLine("Parse Failed");
                        return false;
                    }



                    this.TempC = (float)outValue / 1000.0;

                    //this.TempF = Utilities.ConvertTemp.ConvertCelsiusToFahrenheit(this.TempC);

                    //Console.WriteLine(outValue);
                    //Console.WriteLine(this.TempC);
                    //Console.WriteLine(this.TempF);

                }



            }

            return true;
        }

        private void TempUpdated()
        {
            if (TemperatureUpdated != null)
            {
                TemperatureUpdated(this, new EventArgs());
            }
        }
    }
}
