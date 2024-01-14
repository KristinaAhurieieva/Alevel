using System;
namespace HomeWorkShoppingCart.Entities
{
	public class CartEntity
	{
		public List<string> productIds { get; set; }
		public decimal sum { get; set; }

		public CartEntity()
		{
			productIds = new List<string>();
			sum = 0;
		}

	}
}

