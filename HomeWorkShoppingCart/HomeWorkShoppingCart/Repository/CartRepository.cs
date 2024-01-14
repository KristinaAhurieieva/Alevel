using HomeWorkShoppingCart.Entities;

namespace HomeWorkShoppingCart.Repository
{
    public class CartRepository
    {
        public CartEntity cartStorage { get; } = new CartEntity();

        public void AddProductCart(string productId, decimal sum)
        {
            cartStorage.productIds.Add(productId);
            cartStorage.sum += sum;
        }

        public CartEntity GetCart()
        {
            return cartStorage;
        }

        public void ClearCart()
        {
            cartStorage.productIds.Clear();
            cartStorage.sum = 0;
        }
    }

}