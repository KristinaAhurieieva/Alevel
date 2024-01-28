using System;
using HomeWorkSalad.Models;
using HomeWorkSalad.Repositories.Abstractions;
using HomeWorkSalad.Service.Abstractions;

namespace HomeWorkSalad.Service
{
	public class SaladService :  ISaladService
    {
        private readonly ISaladRepository saladRepository;

        public SaladService(ISaladRepository saladRepository)
        {
            this.saladRepository = saladRepository;
        }

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
        private Vegetable[] vegetables = new Vegetable[5];

        public void DisplayVegetables()
        {
            for (int i = 0; i < vegetables.Length; i++)
            {
                if (vegetables[i] != null)
                {
                    Console.WriteLine($"Name: {vegetables[i].Name},Id: {vegetables[i].Id},Type: {vegetables[i].Type}, Weight: {vegetables[i].Weight}, Calories: {vegetables[i].CalculateCalories()}");
                }
            }
        }

        public void SortByWeight()
        {
            Array.Sort(vegetables, new SortingVegetableService());
        }

        public Vegetable[] SearchVegetablesInSalad(double weight)
        {
            Vegetable[] foundVegetable = new Vegetable[vegetables.Length];
            int count = 0;

            foreach (Vegetable vegetable in vegetables)
            {
                if (vegetable != null && vegetable.Weight == weight)
                {
                    foundVegetable[count] = vegetable;
                    count++;
                }
            }

            return foundVegetable;
        }
        public decimal CalculateTotalCalories()
        {
            decimal allCalories = 0;

            foreach (var vegetable in vegetables)
            {
                if (vegetable != null)
                {
                    allCalories += vegetable.CalculateCalories();
                }
            }

            return allCalories;
        }
    }
}

