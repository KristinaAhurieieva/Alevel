using System;
using Program;
using HomeWorkShoppingCart.Repository;
namespace HomeWorkShoppingCart.Models
{
    public class ShopCart
    {
        public List<Product> productNames { get; } = new List<Product>();

        public void AddToCart(Product product)
        {
            productNames.Add(product);
            Console.WriteLine($"Product \"{product.Name}\" added to your cart.");
        }

        public void DisplayCart()
        {
            Console.WriteLine("The products in the cart:");
            foreach (var item in productNames)
            {
                Console.WriteLine($"Id: {item.Id} - Name: {item.Name} - Price: {item.Price:C}");
            }
        }
    }
}

