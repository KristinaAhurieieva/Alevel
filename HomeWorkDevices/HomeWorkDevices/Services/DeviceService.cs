using System;
using HomeWorkDevices.Models;
using HomeWorkDevices.Enums;
using HomeWorkDevices.Entities;
using HomeWorkDevices.Repositories;
using HomeWorkDevices.Services.Abstractions;

namespace HomeWorkDevices.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly DeviceRepository deviceRepository;

        public DeviceService(DeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public Devices FindDeviceWithMinPower()
        {
            if (deviceRepository.Devices == null || deviceRepository.Devices.Count == 0)
            {
                return null;
            }

            Devices minPowerDevice = deviceRepository.Devices[0];

            foreach (var device in deviceRepository.Devices)
            {
                if (device.PowerConsumption < minPowerDevice.PowerConsumption)
                {
                    minPowerDevice = device;
                }
            }

            return minPowerDevice;
        }

        public void SortDevicesByCategory()
        {
            deviceRepository.Devices.Sort(new SortingService());
        }
        public double CalculateTotalPowerConsumption()
        {
            double totalPowerConsumption = 0.0;

            foreach (var device in deviceRepository.Devices)
            {
                totalPowerConsumption += device.PowerConsumption;
            }

            return totalPowerConsumption;
        }
    }
}
