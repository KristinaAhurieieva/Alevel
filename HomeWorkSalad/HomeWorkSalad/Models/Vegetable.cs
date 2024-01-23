
using HomeWorkSalad.Models.Abstractions;

namespace HomeWorkSalad.Models
{
    public abstract class Vegetable : Ingredient, IVegetable
    {
        public string Type { get; set; }
        public decimal Calories { get; set; }

        public Vegetable(string name, double weight, int id, string type, decimal calories)
            : base(name, weight, id)
        {
            Type = type;
            Calories = calories;
        }
    }
}

