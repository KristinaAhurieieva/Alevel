using System;
using HomeWorkSalad.Service;
using HomeWorkSalad.Repositories;
using HomeWorkSalad.Models;
using HomeWorkSalad.Repositories.Abstractions;
using HomeWorkSalad.Service.Abstractions;

namespace HomeWorkSalad
{
	public class Cooking
	{
        private readonly ISaladService _saladService;
        private readonly IVegetableRepository _vegetableRepository;

        public Cooking(ISaladService saladService, IVegetableRepository vegetableRepository)
        {
            _saladService = saladService;
            _vegetableRepository = vegetableRepository;
        }

        public void MakeSalade()
        {
            foreach (var vegetable in _vegetableRepository.GetAllVegetable())
            {
                Console.WriteLine("Add vegetable in salad (click enter)");
                Console.ReadLine();
                _saladService.AddVegetable(vegetable);
                Console.WriteLine($"Your vegetable add in salad : {vegetable}");

            }
            _saladService.DisplayVegetables();
            
            _saladService.SortByWeight();

            Console.WriteLine("Sorted vegetables:");
            _saladService.DisplayVegetables();

            double weightToSearch = 0.5;
            Console.WriteLine($"Your vegetables sorted by weight {weightToSearch}:");

            foreach (var vegetable in _saladService.SearchVegetablesInSalad(weightToSearch))
            {
                if (vegetable != null)
                {
                    Console.WriteLine($"Name: {vegetable.Name}, Weight: {vegetable.Weight}, Calories: {vegetable.CalculateCalories()}");
                }
            }
            decimal allCalories = _saladService.CalculateTotalCalories();
            Console.WriteLine($"Total calories of the salad: {allCalories}");
        }
    }
}

