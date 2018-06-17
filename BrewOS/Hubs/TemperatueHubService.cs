using Microsoft.AspNetCore.SignalR;
using OneWire;
using System;
using System.Linq;

namespace BrewOS.Hubs
{
    public class TemperatueHubService
    {

        private OneWireBus _Bus = OneWireBus.Instance;

        //private BrewOSContext _Context;
        private IHubContext<TemperatueHub> _hubContext;
        public TemperatueHubService(IHubContext<TemperatueHub> hubContext)
        {
            _hubContext = hubContext;
            //this._Context = context;
            
            this._Bus.UpdateCycleComplete   += Bus_UpdateCycleCompleteAsync;
            //this._Bus.DeviceAdded           += Bus_DeviceAdded;
        }

        private void Bus_DeviceAdded(object sender, DeviceAddedEvent e)
        {
          //  if (e.Device.Type == DeviceType.DS18B20)
          //      this.AddDevice(e.Device as TempSensorDS18B20);
        }

        private void Bus_UpdateCycleCompleteAsync(object sender, EventArgs e)
        {
            this.UpdateTemps();
        }

        private void UpdateTemps()
        {
            //List<Task> taskList = new List<Task>();

            //lock (_Bus.DeviceLock)
            //{
                foreach (var sensor in _Bus.Devices.Where(x => x.Type == DeviceType.DS18B20).Select(x => x as TempSensorDS18B20).ToList())
                {
                    //Console.WriteLine("Sending Temp");
                
                    this._hubContext
                    .Clients
                    .All
                    .SendAsync("Message", sensor.Address, sensor.TempF.ToString(), sensor.Available).Wait();//, sensor.Available.ToString());
                }
    
            //}

            //await Task.WhenAll(taskList);
        }

        //protected override void Dispose(bool disposing)
        //{
        //
        //    Console.WriteLine("Hub Disposed");
        //    this._Bus.UpdateCycleComplete -= Bus_UpdateCycleCompleteAsync;
        //    //this._Bus.DeviceAdded -= Bus_DeviceAdded;

        //    base.Dispose(disposing);
        //}

        
        //private async void AddDevice(TempSensorDS18B20 sensor)
        //{
        //await Clients.All.SendAsync("AddDevice", sensor.Address, sensor.TempF, sensor.Available);
        //}
    }
}
