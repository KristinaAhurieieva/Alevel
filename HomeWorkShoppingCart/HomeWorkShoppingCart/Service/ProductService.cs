using System;
using HomeWorkShoppingCart.Models;
using HomeWorkShoppingCart.Repository;
using HomeWorkShoppingCart.Entity;
using System.Diagnostics;
using System.Xml.Linq;

namespace HomeWorkShoppingCart.Servise
{
	public class ProductService
	{
        private readonly ProductRepository productRepository = new ProductRepository();

        private string[] productNames = { "Melon", "Cucumber", "Cabbage", "Strawberry", "Apple", "Lime", "Avocado", "Orange",
                                  "Lemon", "Mango", "Banana", "Apricot", "Cherry", "Corn", "Pepper", "Tomatoes", "Onion" };
        private const int maxPrice = 50;
        private const int decimalPoint = 2;

        public string GenerateProduct()
        {
            Random random = new Random();
            int indexProductName = random.Next(0, productNames.Length - 1);
            string productName = productNames[indexProductName];
        decimal randomPrice = Math.Round((decimal)random.NextDouble() * maxPrice, decimalPoint);

            return productRepository.AddProduct(productName, randomPrice);
        }

        public new Product? GetProduct(string id)
        {
           ProductEntity product = productRepository.GetProduct(id);

            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public List<Product> GetProductList()
        {
            List<ProductEntity> productEntities = productRepository.GetProductList();
            List<Product> productList = new List<Product>();
            foreach(ProductEntity productEntity in productEntities)
            {

                productList.Add(new Product()
                {
                    Id = productEntity.Id,
                    Name = productEntity.Name,
                    Price = productEntity.Price
                });
            };
            return productList;        }

    }
}

