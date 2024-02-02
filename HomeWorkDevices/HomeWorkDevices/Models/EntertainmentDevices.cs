using System;
using System.Xml.Linq;
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Models
{
	public class EntertainmentDevices : Devices
	{
		public EntertainmentDevices(ItemType itemType, string name, double powerConsumption)
			: base(itemType, Category.Entertainment, name, powerConsumption)
		{

		}
    }
}

