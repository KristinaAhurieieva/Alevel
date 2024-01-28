
using HomeWorkSalad.Models;
using HomeWorkSalad.Repositories.Abstractions;

namespace HomeWorkSalad.Repositories
{
    public class SaladRepository : ISaladRepository
    {
        public Vegetable[] vegetables = new Vegetable[5];

        public void AddVegetable(Vegetable vegetable)
        {
            for (int firstIdx = 0; firstIdx < vegetables.Length; firstIdx++)
            {
                if (vegetables[firstIdx] == null)
                {
                    vegetables[firstIdx] = vegetable;
                    return;
                }
            }
        }
            

        
    }
}

