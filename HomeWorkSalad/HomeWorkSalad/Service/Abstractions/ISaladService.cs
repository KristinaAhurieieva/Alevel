
using HomeWorkSalad.Models;

namespace HomeWorkSalad.Service.Abstractions
{
    public interface ISaladService
    {
        void AddVegetable(Vegetable vegetable);
        void DisplayVegetables();
        void SortByWeight();
        Vegetable[] SearchVegetablesInSalad(double weight);
        decimal CalculateTotalCalories();
    }
}

