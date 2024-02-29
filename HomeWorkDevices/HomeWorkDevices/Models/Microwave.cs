
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Models
{
	public class Microwave : KitchenDevices
    {
        public bool HasGrill { get; set; }
        public bool HasTimer { get; set; }

        public Microwave(string name, double powerConsumption, bool hasGrill, bool hasTimer) : base(ItemType.Microwave, name, powerConsumption)
		{
            HasGrill = hasGrill;
            HasTimer = hasTimer;
        }
	}
}

