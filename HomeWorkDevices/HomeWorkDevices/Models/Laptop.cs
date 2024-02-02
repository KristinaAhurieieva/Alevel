using System;
using System.Xml.Linq;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class Laptop : EntertainmentDevices
    {
		public Laptop(string name, double powerConsumption): base(ItemType.Laptop, name, powerConsumption)
		{
        }
        
    }
}

