using System;
namespace SweetGift.Entities
{
    public class SweetEntity
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
        public string Flavour { get; set; }

        public SweetEntity(string name, double weight, string type, int id, string flavour)
        {
            Name = name;
            Weight = weight;
            Type = type;
            Id = id;
            Flavour = flavour;
        }
    }
}

