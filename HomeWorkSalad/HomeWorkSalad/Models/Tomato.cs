

namespace HomeWorkSalad.Models
{
	public class Tomato : Vegetable
    {
		public Tomato(string name, double weight, int id, string type, decimal calories)
			: base(name, weight, id, type, calories)
		{
		}

        public override decimal CalculateCalories()
        {
            return (decimal)(Weight / 100) * 38.5m;
        }
    }
}

