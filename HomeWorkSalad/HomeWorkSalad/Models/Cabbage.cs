using System;
namespace HomeWorkSalad.Models
{
	public class Cabbage : Vegetable
	{
		public Cabbage(string name, double weight, int id, string type, decimal calories)
            : base(name, weight, id, type, calories)
		{
		}
        public override decimal CalculateCalories()
        {
            return (decimal)(Weight / 100) * 20.48m;
        }
    }
}

