using HomeWorkSalad;
using HomeWorkSalad.Repositories;
using HomeWorkSalad.Repositories.Abstractions;
using HomeWorkSalad.Service;
using HomeWorkSalad.Service.Abstractions;

class Program

{
    static void Main(string[] args)
    {
        ISaladRepository saladRepository = new SaladRepository();
        IVegetableRepository vegetableRepository = new VegetableRepository();
        ISaladService saladService = new SaladService(saladRepository);

        Cooking cooking = new Cooking(saladService, vegetableRepository);

        cooking.MakeSalade();

    }
}

