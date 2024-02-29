
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class GameConsole : EntertainmentDevices
    {
        public string Platform { get; set; } 
        public bool IsPortable { get; set; }

        public GameConsole(string name, double powerConsumption, string platform, bool isPortable) : base(ItemType.GameConsole, name, powerConsumption)
        {
            Platform = platform;
            IsPortable = isPortable;
        }
        
    }
}

