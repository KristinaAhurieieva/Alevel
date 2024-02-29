
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Models
{
	public class Oven : KitchenDevices
	{
        public bool HasConvection { get; set; }

        public Oven(string name, double powerConsumption, bool hasConvection) : base(ItemType.Oven, name, powerConsumption)
        {
            HasConvection = hasConvection;
        }
	}
}

