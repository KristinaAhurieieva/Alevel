using System;
namespace HomeWorkSalad.Models
{
	public abstract class Ingredient
	{
		public string? Name { get; set; }
		public double Weight { get; set; }
		public int Id { get; set; }

		public Ingredient (string name, double weight, int id)
		{
			Name = name;
			Weight = weight;
			Id = id;
		}
        public abstract decimal CalculateCalories();
    }
}

