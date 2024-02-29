
using HomeWorkDevices.Enums;
using HomeWorkDevices.Models;

namespace HomeWorkDevices.Repositories.Abstractions
{
    public interface IDeviceRepository<TDevice> where TDevice : Device
    {
        List<TDevice> GetAllDevices();
        void AddDevice(TDevice device);
        List<TDevice> GetDevicesByCategory(CategoryType categoryType);
    }
}

