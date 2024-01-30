using System;
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Entities
{
	public class DeviceEntity
	{
        public Guid Id { get; set; }
        public ItemType ItemType { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public double PowerConsumption { get; set; }

    }
}

