using System;
namespace eShop
{
    public static class ProductServices
    {
        public static string GetSummary(Product product)
        {
            return $"{product.Vegetable}, Weight: {product.Grams} grams, Added on: {product.DateAdded.ToString("yyyy-MM-dd")}";
        }
    }
}

