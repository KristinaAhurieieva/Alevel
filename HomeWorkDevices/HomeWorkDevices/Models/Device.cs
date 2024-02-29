
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public ItemType ItemType { get; set; }
        public CategoryType CategoryType { get; set; }
        public string Name { get; set; }
        public double PowerConsumption { get; set; }

        public Device(ItemType itemType, CategoryType categoryType, string name, double powerConsumption)
        {
            this.Id = Guid.NewGuid();
            this.ItemType = itemType;
            this.CategoryType = categoryType;
            this.Name = name;
            this.PowerConsumption = powerConsumption;
        }

    }
}

