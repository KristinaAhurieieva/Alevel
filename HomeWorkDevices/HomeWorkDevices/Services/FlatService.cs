using System;
using System.Diagnostics;
using HomeWorkDevices.Models;
using HomeWorkDevices.Repositories;
using HomeWorkDevices.Services.Abstractions;

namespace HomeWorkDevices.Services
{
    public class FlatService : IFlatService
    {
        private readonly FlatModels _flatModels;

        public FlatService(FlatModels flatModels)
        {
            _flatModels = flatModels;
        }
        public void AddDevice(Devices device)
        {
            _flatModels.Devices.Add(device);
        }

        public List<Devices> SortByPowerConsumption()
        {
            return _flatModels.Devices.OrderBy(device => device.PowerConsumption).ToList();
        }

        public List<Devices> FindDevicesWithMinPowerInFlat()
        {
            List<Devices> devices = new List<Devices>();
            List<Devices> sortedDevices = this.SortByPowerConsumption();

            for (int idx = 0; idx < sortedDevices.Count; idx++)
            {
                if (idx != 0 && sortedDevices[idx].PowerConsumption > devices[0].PowerConsumption)
                {
                    break;
                }
                devices.Add(sortedDevices[idx]);
            }

            return devices;
        }

        public void ToggleDevice(bool switchOn)
        {
            _flatModels.Socket.IsSwitchedOn = switchOn;
        }
    }
}

