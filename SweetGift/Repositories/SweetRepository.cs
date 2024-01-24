using System;
using SweetGift.Models;

namespace SweetGift.Repositories
{
	public class SweetRepository
	{
        private Sweet[] sweets = new Sweet[9];

        public SweetRepository()
        {
            SweetBox();
        }

        private void SweetBox()
        {
            sweets[0] = new Candy("Mamba", 0.25, "chewy sweets", 1, "Orange");
            sweets[1] = new Candy("Toffix", 0.02, "chewy sweets", 2, "Watermelon");
            sweets[2] = new Candy("Haribo", 0.35, "chewy sweets", 3, "Coca-cola");
            sweets[3] = new CaramelCandy("Meller", 0.05, "caramel", 4, "chocolate");
            sweets[4] = new CaramelCandy("Roshen", 0.03, "caramel", 5, "barberry");
            sweets[5] = new CaramelCandy("Mentos", 0.50, "caramel", 6, "Pure");
            sweets[6] = new SaltCaramelCandy("Milka", 0.05, "chocolate", 7, "caramel");
            sweets[7] = new SaltCaramelCandy("RitterSport", 0.09, "caramel", 8, "saltCaramel");
            sweets[8] = new SaltCaramelCandy("Roshen", 0.07, "chocolate", 9, "bubble");

            
        }
        public Sweet[] GetAllSweets()
        {
            return sweets;
        }

    }
}

