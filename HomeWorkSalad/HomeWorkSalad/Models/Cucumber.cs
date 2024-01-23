using System;
namespace HomeWorkSalad.Models
{
	public class Cucumber :Vegetable
	{
		public Cucumber(string name, double weight, int id, string type, decimal calories)
            : base(name, weight, id, type, calories)
		{
		}

        public override decimal CalculateCalories()
        {
            return (decimal)(Weight / 100) * 87.78m;
        }
    }
}

