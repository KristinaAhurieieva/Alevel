using System;
using HomeWorkDevices.Enums;
using HomeWorkDevices.Models;

namespace HomeWorkDevices.Repositories
{
    public class DeviceRepository
    {
        public List<Devices> Devices { get; private set; }

        public DeviceRepository()
        {
            Devices = new List<Devices>
            {

            new Devices(ItemType.TV, Category.Entertainment, "TV", 100.0),
            new Devices(ItemType.Laptop, Category.Entertainment, "Laptop", 50.0),
            new Devices(ItemType.GameConsole, Category.Entertainment, "GameConsole", 70.0),
            new Devices(ItemType.Fridge, Category.Kitchen, "Fridge", 110.0),
            new Devices(ItemType.Oven, Category.Kitchen, "Oven", 30.0),
            new Devices(ItemType.Microwave, Category.Kitchen, "Microwave", 10.0)

           };
        }
    }
}




