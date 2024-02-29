using HomeWorkDevices.Models;
using HomeWorkDevices.Services.Abstractions;
using HomeWorkDevices.Repositories.Abstractions;

namespace HomeWorkDevices.Services
{
    public class DeviceService<TDevice> : IDeviceService<TDevice> where TDevice : Device
    {
        private readonly IDeviceRepository<TDevice> _deviceRepository;
        private readonly SocketService _socketService;

        public DeviceService(IDeviceRepository<TDevice> deviceRepository, SocketService socketService)
        {
            _deviceRepository = deviceRepository;
            _socketService = socketService;
        }

        public TDevice FindDeviceWithMinPower()
        {
            if (!_deviceRepository.GetAllDevices().Any())
            {
                return default;
            }

            return _deviceRepository.GetAllDevices().Aggregate((min, d) => d.PowerConsumption < min.PowerConsumption ? d : min);
        }

        public List<TDevice> SortByPowerConsumption()
        {
            return _deviceRepository.GetAllDevices().OrderBy(device => device.PowerConsumption).ToList();
        }

        public double CalculateTotalPowerConsumption()
        {
            return _deviceRepository.GetAllDevices().Sum(device => device.PowerConsumption);
        }

        public void AddDevice(TDevice device)
        {
            _deviceRepository.AddDevice(device);
        }

        public void ToggleDevice(bool switchOn)
        {
            if (switchOn)
            {
                TDevice minPowerDevice = FindDeviceWithMinPower();

                _socketService.ConnectDevice(minPowerDevice);
            }
            else
            {
                _socketService.DisconnectDevice();
            }
        }

    }
}