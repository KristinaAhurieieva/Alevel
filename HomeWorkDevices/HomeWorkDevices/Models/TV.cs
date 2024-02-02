using System;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class TV : EntertainmentDevices
    {
		public TV(string name, double powerConsumption) : base(ItemType.TV, name, powerConsumption)
        {
         

        }
       
    }
}

