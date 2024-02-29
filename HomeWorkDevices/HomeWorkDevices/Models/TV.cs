
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
	public class TV : EntertainmentDevices
    {
        public bool IsSmart { get; set; }

        public TV(string name, double powerConsumption, bool isSmart) : base(ItemType.TV, name, powerConsumption)
        {
            IsSmart = isSmart;

        }
       
    }
}

