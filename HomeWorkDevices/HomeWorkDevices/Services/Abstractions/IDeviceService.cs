using System;
using HomeWorkDevices.Models;

namespace HomeWorkDevices.Services.Abstractions
{
	public interface IDeviceService 
	{
        Devices FindDeviceWithMinPower();
        void SortDevicesByCategory();
        double CalculateTotalPowerConsumption();
    }
}

