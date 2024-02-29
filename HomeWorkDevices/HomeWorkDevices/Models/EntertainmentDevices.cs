
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Models
{
	public class EntertainmentDevices : Device
	{
		public EntertainmentDevices(ItemType itemType, string name, double powerConsumption)
			: base(itemType, CategoryType.Entertainment, name, powerConsumption)
		{

		}
    }
}

