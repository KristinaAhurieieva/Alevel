using System;
using HomeWorkDevices.Enums;
using HomeWorkDevices.Models;
namespace HomeWorkDevices.Services.Abstractions
{
    public interface IFlatService
    {
        void ToggleDevice(bool switchOn);
        List<Devices> FindDevicesWithMinPowerInFlat();
        List<Devices> SortByPowerConsumption();
        void AddDevice(Devices device);
    }

}

