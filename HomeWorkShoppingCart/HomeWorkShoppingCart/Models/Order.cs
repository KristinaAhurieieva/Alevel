using System;

namespace HomeWorkShoppingCart.Models
{
	public class Order
	{
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> OrderedItems { get; set; } = new List<Product>();

    }
}

