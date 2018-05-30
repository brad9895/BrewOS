using BrewOS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.Vessels
{
    public class Vessels
    {
        public List<Dispenser> Dispensers { get; private set; }
        public List<Fermenter> Fermenters { get; private set; }

        private Vessels()
        {
            var context = BrewOSContext.Instance;

            Dispensers = context.Dispensers.Include(x => x.OnTap).ToList();
            Fermenters = context.Fermenters.Include(x => x.Wort).ToList();

        }

        private static Vessels _Instance = null;
        public static Vessels Instance
        {
            get { return _Instance != null ? _Instance : createInstance(); }
        }

        private static Vessels createInstance()
        {
            _Instance = new Vessels();
            return Instance;
        }
    }
}
