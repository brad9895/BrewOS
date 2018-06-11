using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace OneWire
{
    public abstract class OneWireDevice : INotifyPropertyChanged
    {
        [Key]
        public string Address { get; protected set; }

        private const string _OneWireDir = "//sys//bus//w1//devices";

        public DeviceType Type { get; private set; }

        

        public bool Available { get; protected set; }

        protected List<string> _RawData = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected OneWireDevice(DeviceType Type)
        {
            this.Type = Type;
        }

        public virtual bool UpdateReading()
        {
            this._RawData = ReadSensor();

            if (!this._RawData.Any())
            {
                //Console.WriteLine("No Data Found");
                this.Available = false;
            }
            else
                this.Available = true;

            return Available;
        }

        protected List<string> ReadSensor()
        {
            string sensorFile = _OneWireDir + "//" + Address + "//w1_slave";

            List<string> list = new List<string>();

            if (File.Exists(sensorFile))
            {
                //var reader = new CsvReader(sensorFile, ' ');
                var reader = File.ReadAllLines(@sensorFile);

                list.AddRange(reader);

                //while (reader.ReadRecord())
                //{
                //    list.Add(reader.RawRecord);
                //}
                
                
            }

            return list;
        }

        protected void NotifyPropertyChanged(string propertyKey)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyKey));
        }
    }

    public enum DeviceType
    {
        DS18B20,
        UNKNOWN
    }

}
