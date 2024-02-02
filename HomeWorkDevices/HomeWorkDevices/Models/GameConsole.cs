using System;
using System.Xml.Linq;
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class GameConsole : EntertainmentDevices
    {
		public GameConsole(string name, double powerConsumption): base(ItemType.GameConsole, name, powerConsumption)
        {

        }
        
    }
}

