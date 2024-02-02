using System;
using HomeWorkDevices.Services;
using HomeWorkDevices.Enums;
using HomeWorkDevices.Models;
using HomeWorkDevices.Services.Abstractions;
using System.Diagnostics;
using HomeWorkDevices.Repositories;

namespace HomeWorkDevices
{
    public class StartConnection
    {
        private readonly IFlatService _flatService;
        private readonly IDeviceService _deviceService;
        private readonly ILoggerService _loggerService;
        private readonly DeviceRepository _deviceRepository;

        public StartConnection(IFlatService flatService, IDeviceService deviceService, ILoggerService loggerService, DeviceRepository deviceRepository)
        {
            _flatService = flatService;
            _deviceService = deviceService;
            _loggerService = loggerService;
            _deviceRepository = deviceRepository;

            foreach (var device in deviceRepository.Devices)
            {
                flatService.AddDevice(device);
            }
            double totalPowerConsumption = deviceService.CalculateTotalPowerConsumption();
            loggerService.Log(LogType.Message, $"Total power consumption: {totalPowerConsumption} Wt");

            flatService.ToggleDevice(true);
            loggerService.Log(LogType.Message, "Devices are connected");

            Devices minPowerDevice = deviceService.FindDeviceWithMinPower();
            loggerService.Log(LogType.Message, $"Device with minimum power consumption: {minPowerDevice.Name}");

            deviceService.SortDevicesByCategory();

            loggerService.Log(LogType.Message, "Executed successfully.");
        }
    }
}

