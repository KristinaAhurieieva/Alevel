using HomeWorkDevices.Enums;
using HomeWorkDevices.Models;
using HomeWorkDevices.Repositories.Abstractions;

namespace HomeWorkDevices.Repositories
{
    public class DeviceRepository<TDevice> : IDeviceRepository<TDevice> where TDevice : Device
    {
        public List<TDevice> Devices { get; set; }

        public DeviceRepository()
        {
            Devices = new List<TDevice>
        {
            (TDevice)new Device(ItemType.TV, CategoryType.Entertainment, "TV", 100.0),
            (TDevice)new Device(ItemType.Laptop, CategoryType.Entertainment, "Laptop", 50.0),
            (TDevice)new Device(ItemType.GameConsole, CategoryType.Entertainment, "GameConsole", 70.0),
            (TDevice)new Device(ItemType.Fridge, CategoryType.Kitchen, "Fridge", 110.0),
            (TDevice)new Device(ItemType.Oven, CategoryType.Kitchen, "Oven", 30.0),
            (TDevice)new Device(ItemType.Microwave, CategoryType.Kitchen, "Microwave", 10.0)
        };
        }

        public List<TDevice> GetAllDevices()
        {
            return Devices;
        }

        public void AddDevice(TDevice device)
        {
            Devices.Add(device);
        }

        public List<TDevice> GetDevicesByCategory(CategoryType categoryType)
        {
            return Devices.Where(d => d.CategoryType == categoryType).ToList();
        }

        
    }
}




