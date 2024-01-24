using System;
namespace SweetGift.Models
{
    public class SaltCaramelCandy : CaramelCandy
    {
        public SaltCaramelCandy(string name, double weight, string type, int id, string flavour)
            : base(name, weight, type, id, flavour)
        {
        }

        public override void Display()
        {
            base.Display();
        }
    }
}
