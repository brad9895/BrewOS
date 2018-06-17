using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneWire;

namespace BrewOS.Models
{
    public abstract class Card
    {
        public string name { set; get; }
        public string style { set; get; }
        public string image { set; get; }
    }
    public class FermenterCard: Card
    {
        public string fermenterName { set; get; }
        public double actualTemp { set; get; }
        public double targetTemp { set; get; }
        public double initialGravity { set; get; }
        public string brewDate { set; get; }
        public string estCompletionDate { set; get; }

        //public string SensorName { set; get; }
        //public TempSensorDS18B20 Sensor { get; set; }

    }
    public class OnTapCard : Card
    {
        public string onTapName { set; get; }
        public string abv { set; get; }
        public string description { set; get; }
    }
}
