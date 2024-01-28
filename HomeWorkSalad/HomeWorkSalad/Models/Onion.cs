using System;
namespace HomeWorkSalad.Models
{
	public class Onion : Vegetable
	{
		public Onion(string name, double weight, int id, string type, decimal calories)
            : base(name, weight, id, type, calories)
		{
        }

        public override decimal CalculateCalories()
        {
            return (decimal)(Weight / 100) * 05.43m;
        }
    }
}

