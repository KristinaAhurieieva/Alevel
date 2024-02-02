using System;
using System.Xml.Linq;
using HomeWorkDevices.Enums;

namespace HomeWorkDevices.Models
{
	public class Microwave : KitchenDevices
    {
		public Microwave(string name, double powerConsumption) : base(ItemType.Microwave, name, powerConsumption)
		{
           
        }
	}
}

