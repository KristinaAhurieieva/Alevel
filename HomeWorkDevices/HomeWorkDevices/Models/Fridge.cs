
using HomeWorkDevices.Enums;
namespace HomeWorkDevices.Models
{
    public class Fridge : KitchenDevices
    {
        public bool IsFreezer { get; set; }
        public int Shelves { get; set; }

        public Fridge(string name, double powerConsumption, bool isFreezer, int shelves) : base(ItemType.Fridge, name, powerConsumption)
        {
            IsFreezer = isFreezer;
            Shelves = shelves;
        }
    }
}

