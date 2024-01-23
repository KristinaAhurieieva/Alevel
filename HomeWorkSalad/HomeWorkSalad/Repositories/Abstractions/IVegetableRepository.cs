
using HomeWorkSalad.Models;

namespace HomeWorkSalad.Repositories.Abstractions
{
    public interface IVegetableRepository
    {
        Vegetable[] GetAllVegetable();
        void AddVegetableInSalad(Vegetable vegetable);
    }
}

