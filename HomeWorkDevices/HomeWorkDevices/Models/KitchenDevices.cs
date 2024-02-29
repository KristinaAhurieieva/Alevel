
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class KitchenDevices : Device
	{
		public KitchenDevices(ItemType itemType, string name, double powerConsumption)
			: base(itemType, CategoryType.Kitchen, name, powerConsumption)
		{
		}
	}
}

