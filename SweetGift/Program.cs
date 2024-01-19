using System.Xml.Linq;
using SweetGift.Models;
using SweetGift.Repositories;
using SweetGift.Service;

class Program

{
    static void Main(string[] args)
    {

        SweetService sweetService = new SweetService();
        GiftBoxService giftBoxService = new GiftBoxService();

        giftBoxService.AddSweetToGiftBox(new Candy($"Mamba", 0.25, "chewy sweets", 1, "Orange"));
        giftBoxService.AddSweetToGiftBox(new SaltCaramelCandy("Milka", 0.05, "chocolate", 7, "caramel"));
        giftBoxService.AddSweetToGiftBox(new CaramelCandy("Roshen", 0.05, "caramel", 2, "Vanilla"));

        giftBoxService.DisplaySweetsInGiftBox();

        double totalWeight = giftBoxService.GetTotalWeightOfGiftBox();
        Console.WriteLine($"Total weight of the gift box: {totalWeight} gr");

        giftBoxService.SortGiftBoxByFlavour();

        Console.WriteLine("Sweets in the Gift Box after sorting by flavour:");
        giftBoxService.DisplaySweetsInGiftBox();

        string desiredFlavour = "Vanilla";
        Sweet[] foundSweets = sweetService.GetSweetsByFlavour(desiredFlavour);

        Console.WriteLine($"Sweets with flavour '{desiredFlavour}':");
        foreach (Sweet sweet in foundSweets)
        {
            sweet?.Display();
        }
        Console.ReadKey();
    }
}