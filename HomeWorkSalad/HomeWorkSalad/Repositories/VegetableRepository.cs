
using HomeWorkSalad.Models;
using HomeWorkSalad.Repositories.Abstractions;

namespace HomeWorkSalad.Repositories
{
    public class VegetableRepository : IVegetableRepository
    {
        private Vegetable[] vegetables = new Vegetable[5];

        public VegetableRepository()
        {
            BoxVegetable();
        }

        private void BoxVegetable()
        {
            vegetables[0] = new Tomato("Tomato", 0.250, 1, "vegetable", 38.5m);
            vegetables[1] = new Cabbage("Cabbage", 0.50, 2, "vegetable", 20.48m);
            vegetables[2] = new Cucumber("Cucumber", 0.45, 3, "vegetable", 87.78m);
            vegetables[3] = new Pepper("Pepper", 0.08, 4, "vegetable", 87.65m);
            vegetables[4] = new Onion("Onion", 0.03, 5, "vegetable", 05.43m);
            
        }

        public Vegetable[] GetAllVegetable()
        {
            Vegetable[] result = new Vegetable[vegetables.Length];

            for (int i = 0; i < vegetables.Length; i++)
            {
                result[i] = vegetables[i];
            }

            return result;
        }

        public void AddVegetableInSalad(Vegetable vegetable)
        {
            for (int i = 0; i < vegetables.Length; i++)
            {
                if (vegetables[i] == null)
                {
                    vegetables[i] = vegetable;
                    break;
                }
            }
        }
    }
}

