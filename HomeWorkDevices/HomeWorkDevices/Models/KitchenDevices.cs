using System;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class KitchenDevices : Devices
	{
		public KitchenDevices(ItemType itemType, string name, double powerConsumption)
			: base(itemType, Category.Kitchen, name, powerConsumption)
		{
		}
	}
}

