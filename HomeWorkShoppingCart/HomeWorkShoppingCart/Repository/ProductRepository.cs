using System;
using HomeWorkShoppingCart.Entity;
using HomeWorkShoppingCart.Models;

namespace HomeWorkShoppingCart.Repository
{
    public class ProductRepository
    {
        public List<ProductEntity> productsStorage { get; } = new List<ProductEntity>();

        public string AddProduct(string name, decimal price)
        {
            var product = new ProductEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Price = price
            };

            productsStorage.Add(product);
            return product.Id;
        }

        public ProductEntity GetProduct(string id)
        {
            foreach (var item in productsStorage)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public List<ProductEntity> GetProductList()
        {
            return productsStorage;
        }
    }

    
}

