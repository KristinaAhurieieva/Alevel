using System;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
    public class Devices
    {
        public Guid Id { get; set; }
        public ItemType ItemType { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public double PowerConsumption { get; set; }

        public Devices(ItemType itemType, Category category, string name, double powerConsumption)
        {
            this.Id = Guid.NewGuid();
            this.ItemType = itemType;
            this.Category = category;
            this.Name = name;
            this.PowerConsumption = powerConsumption;
        }

    }
}

