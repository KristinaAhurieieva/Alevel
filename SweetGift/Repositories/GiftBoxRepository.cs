using System;
using SweetGift.Models;
using SweetGift.Service;

namespace SweetGift.Repositories
{
	public class GiftBoxRepository
	{
        private Sweet[] sweets = new Sweet[9];

        public void Add(Sweet sweet)
        {
            for (int firstIdx = 0; firstIdx < sweets.Length; firstIdx++)
            {
                if (sweets[firstIdx] == null)
                {
                    sweets[firstIdx] = sweet;
                    Console.WriteLine($"Your sweet {sweet.Name} added in Gift Box");
                    return;
                }
            }
        }

        public double GetTotalWeight()
        {
            double totalWeight = 0;

            foreach (Sweet sweet in sweets)
            {
                if (sweet != null)
                {
                    totalWeight += sweet.Weight;
                }
            }
            return totalWeight;
            
        }

        public void DisplaySweets()
        {
            
            foreach (Sweet sweet in sweets)
            {
                if (sweet != null)
                {
                    sweet.Display();
                }
            }
        }

        public void SortByFlavour()
        {
            Array.Sort(sweets, new SortingService());
        }

        public Sweet[] SearchSweet(string flavour)
        {
            Sweet[] foundSweets = new Sweet[sweets.Length];
            int count = 0;

            foreach (Sweet sweet in sweets)
            {
                if (sweet != null && sweet.Flavour == flavour)
                {
                    foundSweets[count] = sweet;
                    count++;
                }
            }

            return foundSweets;
        }
    }
}

