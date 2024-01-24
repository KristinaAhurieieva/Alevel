using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SweetGift.Models
{
	public class Candy : Sweet
    {

        public Candy(string name, double weight,string type, int id,string flavour )
            : base(name, weight, type, id, flavour)
        {
        }

        public override void Display()
        {
            base.Display();
            
        }
    }
}

