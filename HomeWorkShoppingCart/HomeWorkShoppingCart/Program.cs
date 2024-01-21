
using HomeWorkShoppingCart.Models;
using HomeWorkShoppingCart.Repository;
using HomeWorkShoppingCart.Servise;
using HomeWorkShoppingCart.Entities;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            CartRepository cartRepository = new CartRepository();
            CartService cartService = new CartService(cartRepository, productService);
            OrderService orderService = new OrderService(cartService, productService);

            for (int i = 0; i < 5; i++)
            {
                cartService.AddProduct(productService.GenerateProduct(), 50);
            }
            Console.WriteLine(cartService.DisplayCart());

            orderService.PlaceOrder();

            Order lastOrder = orderService.GetLastOrder();
            Bill bill = orderService.GetBill(lastOrder);

            bill.DisplayBill();
        }
    
    }
}