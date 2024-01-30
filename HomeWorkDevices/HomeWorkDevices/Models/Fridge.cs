using System;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class Fridge : KitchenDevices
	{
        public Fridge(string name, double powerConsumption) : base(ItemType.Fridge, name, powerConsumption)
		{
          
        }
	}
}

