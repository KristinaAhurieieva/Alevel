
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Entities
{
	public class DeviceEntity
	{
        public Guid Id { get; set; }
        public ItemType ItemType { get; set; }
        public CategoryType CategoryType { get; set; }
        public string Name { get; set; }
        public double PowerConsumption { get; set; }

    }
}

