using System;
using HomeWorkDevices.Models;

namespace HomeWorkDevices.Services.Abstractions
{
    public interface IDeviceService<TDevice> where TDevice : Device
    {
        TDevice FindDeviceWithMinPower();
        double CalculateTotalPowerConsumption();
        List<TDevice> SortByPowerConsumption();
        void AddDevice(TDevice device);
        void ToggleDevice(bool switchOn);
    }
}

