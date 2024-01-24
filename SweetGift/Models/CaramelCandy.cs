using System;
namespace SweetGift.Models
{
	public class CaramelCandy : Candy
	{
		public CaramelCandy(string name, double weight, string type, int id, string flavour)
            : base(name, weight, type, id, flavour)
		{
		}
        
        public override void Display()
        {
            base.Display();
            
        }
    }
}

