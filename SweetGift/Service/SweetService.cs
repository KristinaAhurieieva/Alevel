using System;
using SweetGift.Repositories;
using SweetGift.Models;

namespace SweetGift.Service

{
	public class SweetService
	{
        private readonly SweetRepository sweetRepository;
        private readonly GiftBoxRepository giftBoxRepository;

        public SweetService()
        {
            sweetRepository = new SweetRepository();
            giftBoxRepository = new GiftBoxRepository();
        }

        public Sweet[] GetSweetsByFlavour(string Flavour)
        {
            return giftBoxRepository.SearchSweet(Flavour);
        }

        public Sweet[] GetAllSweets()
        {
            return sweetRepository.GetAllSweets();
        }
    }
}

