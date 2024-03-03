using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class Laptop : EntertainmentDevices
    {
        public string OperatingSystem { get; set; } 
        public int Ram { get; set; }

        public Laptop(string name, double powerConsumption, string operatingSystem, int ram) : base(ItemType.Laptop, name, powerConsumption)
		{
            OperatingSystem = operatingSystem;
            Ram = ram;
        }
        
    }
}

