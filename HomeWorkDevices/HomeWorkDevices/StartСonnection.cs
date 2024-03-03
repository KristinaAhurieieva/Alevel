using HomeWorkDevices.Enums;
using HomeWorkDevices.Models;
using HomeWorkDevices.Services.Abstractions;
using HomeWorkDevices.Repositories.Abstractions;

namespace HomeWorkDevices
{
    public class StartConnection
    {
        private readonly IDeviceService<Device> _deviceService;
        private readonly ILoggerService _loggerService;
        private readonly IDeviceRepository<Device> _deviceRepository;

        public StartConnection(IDeviceService<Device> deviceService, ILoggerService loggerService, IDeviceRepository<Device> deviceRepository)
        {
            _deviceService = deviceService;
            _loggerService = loggerService;
            _deviceRepository = deviceRepository;
        }

        public void Start()
        {
            foreach (var device in _deviceRepository.GetAllDevices())
            {
                _deviceService.AddDevice(device);
            }

            double totalPowerConsumption = _deviceService.CalculateTotalPowerConsumption();
            _loggerService.Log(LogType.Message, $"Total power consumption: {totalPowerConsumption} Wt");

            _deviceService.ToggleDevice(true); 
            _loggerService.Log(LogType.Message, "Device is connected");

            Device minPowerDevice = _deviceService.FindDeviceWithMinPower();
            _loggerService.Log(LogType.Message, $"Device with minimum power consumption: {minPowerDevice.Name}");

            _deviceService.SortByPowerConsumption();

            _loggerService.Log(LogType.Message, "Executed successfully.");
        }
    }
}

