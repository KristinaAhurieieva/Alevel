using System;
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Models
{
	public class Oven : KitchenDevices
	{
		public Oven(string name, double powerConsumption) : base(ItemType.Oven, name, powerConsumption)
        {
        }
	}
}

