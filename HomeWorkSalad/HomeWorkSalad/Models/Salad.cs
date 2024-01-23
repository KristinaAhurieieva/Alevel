
using HomeWorkSalad.Models.Abstractions;
namespace HomeWorkSalad.Models
{
    public class Salad : ISalad
    {
        private Vegetable[] vegetables = new Vegetable[6];
        private int index = 0;

        public void AddVegetable(Vegetable vegetable)
        {
            if (index < vegetables.Length)
            {
                vegetables[index] = vegetable;
                index++;
            }
            else
            {
                Console.WriteLine("The salad is overflowing");
            }
        }
    }
}

