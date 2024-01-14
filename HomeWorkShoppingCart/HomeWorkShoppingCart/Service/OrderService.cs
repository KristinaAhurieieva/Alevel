using System;
using HomeWorkShoppingCart.Models;
using HomeWorkShoppingCart.Servise;

namespace HomeWorkShoppingCart.Servise
{
    public class OrderService
    {
        private readonly CartService cartService;
        private readonly List<Order> orders = new List<Order>();
        private readonly ProductService productService;

        public OrderService(CartService cartService, ProductService productService)
        {
            this.cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public void PlaceOrder()
        {
            List<Product> productName = new List<Product>();
            foreach (string productId in cartService.GetCart().productIds)
            {
                Product product = productService.GetProduct(productId);
                if (product != null)
                {
                    productName.Add(product);
                }
            }

            Order order = new Order
            {
                OrderNumber = orders.Count + 1,
                OrderDate = DateTime.Now,
                OrderedItems = productName
            };

            orders.Add(order);
            cartService.ClearCart();

            NotificationService notificationService = new NotificationService();
            notificationService.ShowNotification($"Your order with number {order.OrderNumber} has been successfully placed.");
        }

        public Order GetLastOrder()
        {
            return orders.LastOrDefault();
        }

        public Bill GetBill(Order order)
        {
            decimal totalAmount = order.OrderedItems.Sum(item => item.Price);

            return new Bill
            {
                Id = order.OrderNumber.ToString(),
                Date = order.OrderDate,
                Products = order.OrderedItems,
                Sum = totalAmount
            };
        }
    }

}