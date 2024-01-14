using System;
using HomeWorkShoppingCart.Models;
using HomeWorkShoppingCart.Servise;
using HomeWorkShoppingCart.Repository;
using HomeWorkShoppingCart.Entity;
using HomeWorkShoppingCart.Entities;
using System.Text;

namespace HomeWorkShoppingCart.Servise
{

    public class CartService
    {
        private readonly CartRepository cartRepository;
        private readonly ProductService productService;

        public CartService(CartRepository cartRepository, ProductService productService)
        {
            this.cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public void AddProduct(string productId, decimal sum)
        {
            cartRepository.AddProductCart(productId, sum);
            Product currentProduct = productService.GetProduct(productId);
            string productName = currentProduct?.Name ?? "";
            Console.WriteLine($"Product {productName} added to your cart. Total sum: {cartRepository.GetCart().sum:C}");
        }

        public CartEntity GetCart()
        {
            return cartRepository.GetCart();
        }

        public string? DisplayCart()
        {
            var cart = GetCart();
            if (cart == null)
            {
                return "haven't cart:";
            }

            StringBuilder cartInfo = new StringBuilder();
            cartInfo.AppendLine("Products in the cart:");
            foreach (var productId in cart.productIds)
            {
                Product currentProduct = productService.GetProduct(productId);

                cartInfo.AppendLine($"Product: {currentProduct.Name}");
            }
            cartInfo.AppendLine($"Total sum: {cart.sum:C}");

            return cartInfo.ToString();
        }

        public void ClearCart()
        {
            cartRepository.ClearCart();
            Console.WriteLine("Cart cleared.");
        }
    }
}




