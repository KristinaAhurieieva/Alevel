using System;
using SweetGift.Models;
using SweetGift.Repositories;

namespace SweetGift.Service
{
    public class GiftBoxService
    {
        private readonly GiftBoxRepository giftBoxRepository;
        private readonly SweetRepository sweetRepository;

        public GiftBoxService()
        {
            giftBoxRepository = new GiftBoxRepository();
            sweetRepository = new SweetRepository();
        }

        public void SortGiftBoxByFlavour()
        {
            giftBoxRepository.SortByFlavour();
            giftBoxRepository.DisplaySweets();
        }

        public void SearchInGiftBoxByFlavour(string flavour)
        {
            Sweet[] foundSweets = giftBoxRepository.SearchSweet(flavour);
            foreach (Sweet sweet in foundSweets)
            {
                sweet?.Display();
            }
        }
        public void AddSweetToGiftBox(Sweet sweet)
        {
            giftBoxRepository.Add(sweet);
            
        }
        public void DisplaySweetsInGiftBox()
        {
            giftBoxRepository.DisplaySweets();
        }
        public double GetTotalWeightOfGiftBox()
        {
            return giftBoxRepository.GetTotalWeight();
        }
        
    }
}

