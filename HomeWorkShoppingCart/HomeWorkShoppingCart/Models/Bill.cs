using System;
using HomeWorkShoppingCart.Repository;
using HomeWorkShoppingCart.Servise;
using HomeWorkShoppingCart.Servise;

namespace HomeWorkShoppingCart.Models
{
    public class Bill
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public void DisplayBill()
        {
            Console.WriteLine($"Bill Information:");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Total Sum: {Sum:C}");

            Console.WriteLine("Products in the Bill:");
            foreach (var product in Products)
            {
                Console.WriteLine($"Id: {product.Id} - Name: {product.Name} - Price: {product.Price:C}");
            }
        }
    }
}

