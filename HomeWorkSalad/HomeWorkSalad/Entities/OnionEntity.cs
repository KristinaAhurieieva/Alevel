using System;
namespace HomeWorkSalad.Entities
{
    public class OnionEntity

    {
        public string? Name { get; set; }
        public double Weight { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Calories { get; set; }

        public OnionEntity(string name, double weight, int id, string type, decimal calories)

        {
            Name = name;
            Weight = weight;
            Id = id;
            Type = type;
            Calories = calories;

        }
    }
}

